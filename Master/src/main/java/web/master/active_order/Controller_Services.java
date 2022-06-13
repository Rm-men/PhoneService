package web.master.active_order;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;
import web.master.MainStart;
import web.master.entity.Employee;
import web.master.entity.Order;
import web.master.entity.Service;
import web.master.mains.ControllerActiveOrder;

import java.io.IOException;
import java.net.URL;
import java.sql.*;
import java.util.ResourceBundle;

public class Controller_Services implements Initializable {
    private static Connection con;
    @FXML public Button b_config;
    @FXML public ComboBox cb_category;
    @FXML public Label l_c_services;
    @FXML public Label l_c_price;
    @FXML public Label l_c_time;

    @FXML public TableView tv_all_list;
    private ObservableList<Service> list_All = FXCollections.observableArrayList(); // список услуг, доступных для выбора
    @FXML private TableColumn<Service, String>  col_all_name;
    @FXML private TableColumn<Service, String>  col_all_type;
    @FXML private TableColumn<Service, Double>  col_all_cost;
    @FXML private TableColumn<Service, String>  col_all_time;

    @FXML public TableView tv_cur_list;
    private ObservableList<Service> list_Cur = FXCollections.observableArrayList(); // список выбранных услуг для заказа
    @FXML private TableColumn<Service, String>  col_cur_name;
    @FXML private TableColumn<Service, String>  col_cur_type;
    @FXML private TableColumn<Service, Double>  col_cur_cost;
    @FXML private TableColumn<Service, String>  col_cur_time;

    @FXML private ObservableList<Service> list_Services = FXCollections.observableArrayList(); // общий список всех услуг
    private ObservableList<String> list_Types = FXCollections.observableArrayList();



    public Employee _Employee; // private
    public Order _Order;
    private Stage _stage_detail;
    private Stage _stage_main;


    public Controller_Services(Employee cEmployee, Order order, Stage stage_c, Stage stage_main)
    {
        _Employee = cEmployee;
        _Order = order;
        _stage_detail = stage_c;
        _stage_main = stage_main;
    }

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        try {
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
        } catch (SQLException e) {
            e.printStackTrace();
        }
        list_Types = getTypesList();
        cb_category.getItems().addAll(list_Types);
        b_config.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                configureChanges();
                System.out.println("Click to change services");

                _stage_main.close();
                _stage_detail.close();

                Stage newMainWindow = new Stage();

                { // переоткрыть главное окно

                    FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("main_activeorderf.fxml"));
                    fxmlLoader.setController( new ControllerActiveOrder(_Employee));
                    Scene scene = null;
                    try {
                        scene = new Scene(fxmlLoader.load());
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                    newMainWindow.setTitle("Мастерская - активные заказы");
                    newMainWindow.setScene(scene);
                    newMainWindow.setMaximized(true);
                    newMainWindow.show();
                }

                { // переоткрыть окно деталей
                    Stage newWindow = new Stage();
                    FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("Order_info_picked.fxml"));
                    fxmlLoader.setController( new ControllerActiveOrder_picked(_Employee, _Order, newMainWindow));
                    Scene scene = null;
                    try {
                        scene = new Scene(fxmlLoader.load());
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                    newWindow.setTitle("Мастерская - детализация активного заказа");
                    newWindow.setScene(scene);
                    newWindow.show();
                }

                Stage stage_curr = (Stage) b_config.getScene().getWindow();
                stage_curr.close();
            }
        });
        initData();
        col_all_name.setCellValueFactory(new PropertyValueFactory<Service, String>("namesrv"));
        col_all_type.setCellValueFactory(new PropertyValueFactory<Service, String>("typesrv"));
        col_all_cost.setCellValueFactory(new PropertyValueFactory<Service, Double>("costsrv"));
        col_all_time.setCellValueFactory(new PropertyValueFactory<Service, String>("timesrv"));

        col_cur_name.setCellValueFactory(new PropertyValueFactory<Service, String>("namesrv"));
        col_cur_type.setCellValueFactory(new PropertyValueFactory<Service, String>("typesrv"));
        col_cur_cost.setCellValueFactory(new PropertyValueFactory<Service, Double>("costsrv"));
        col_cur_time.setCellValueFactory(new PropertyValueFactory<Service, String>("timesrv"));


        tv_all_list.setItems(list_Services);
        tv_all_list.setRowFactory(rv -> {
            TableRow<Service> row = new TableRow();
            row.setOnMouseClicked(mouseEvent -> {
                Service service = row.getItem();
                try {
                    all_rowClick(service);
                } catch (IOException e) {
                    e.printStackTrace();
                }
            });
            return row;
        });
        tv_cur_list.setItems(list_Cur);
        tv_cur_list.setRowFactory(rv -> {
            TableRow<Service> row = new TableRow();
            row.setOnMouseClicked(mouseEvent -> {
                Service service = row.getItem();
                try {
                    curr_rowClick(service);
                } catch (IOException e) {
                    e.printStackTrace();
                }
            });
            return row;
        });

        cb_category.setOnAction(event -> filters());
        caclTotal();
    }
    private void initData() {
        try {
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            // ResultSet rs = st.executeQuery("SELECT id_order, order_date, phone_number, address, id_client, id_master, id_phone, id_order_status, description, comments, name_model FROM orders_view");
            ResultSet rs = st.executeQuery("SELECT * FROM list_sirvices" );
            while (rs.next()) {
                Service service = new Service();
                service.setId_service(rs.getInt("id"));
                service.setNamesrv(rs.getString("namesrv"));
                service.setDescriptionsrv(rs.getString("descriptionsrv"));
                service.setTypesrv(rs.getString("typesrv"));
                service.setCostsrv(rs.getDouble("costsrv"));
                service.setTimesrv(rs.getString("timesrv"));
                list_Services.add(service);
            }
            PreparedStatement ps = con.prepareStatement("SELECT * FROM on_order_srv JOIN list_sirvices ls on ls.id = on_order_srv.id_srv_onlist WHERE id_order_forservice = ?");
            ps.setInt(1, _Order.getId_order());
            rs = ps.executeQuery();
            while (rs.next()) {
                Service service = new Service();
                service.setId_service(rs.getInt("id"));
                service.setNamesrv(rs.getString("namesrv"));
                service.setDescriptionsrv(rs.getString("descriptionsrv"));
                service.setTypesrv(rs.getString("typesrv"));
                service.setCostsrv(rs.getDouble("costsrv"));
                service.setTimesrv(rs.getString("timesrv"));
                list_Cur.add(service);
            }
            caclTotal();
            rs.close();
            con.close();
        } catch (SQLException e) {
            {
                e.printStackTrace();
            }
        }
    }
    public void all_rowClick(Service service) throws IOException{
        System.out.println("click on all service: "+service.getNamesrv());
        list_Cur.add(service);
        // tv_cur_list.getItems().add(service);
        tv_cur_list.refresh();
        caclTotal();
    }
    public void curr_rowClick(Service service) throws IOException{
        System.out.println("click on curr service: "+service.getNamesrv());
        // tv_cur_list.getItems().remove(service);
        list_Cur.remove(service);
        caclTotal();
    }
    public static ObservableList<String> getTypesList() {
        ObservableList<String> list = FXCollections.observableArrayList();
        try {
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("Select DISTINCT typesrv From list_sirvices");
            while (rs.next()) {
                String stat = rs.getString("typesrv");
                list.add(stat);
            }
            rs.close();
            st.close();
            con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return list;
    }
    private void filters() {
/*        if (cb_category.getValue() != null) {
            status = cb_category.getValue().toString();
        }*/
/*        if (Search.getText() != "") {
            phone = "%" + Search.getText() + "%";
        }*/
        try {
            tv_all_list.getItems().clear();
            // list_Cur.clear();
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            // ResultSet rs = st.executeQuery("SELECT id_order, order_date, phone_number, address, id_client, id_master, id_phone, id_order_status, description, comments, name_model FROM orders_view");
            ResultSet rs = st.executeQuery("SELECT * FROM list_sirvices WHERE typesrv = '"+ cb_category.getValue().toString()+"';" );
            while (rs.next()) {
                Service service = new Service();
                service.setId_service(rs.getInt("id"));
                service.setNamesrv(rs.getString("namesrv"));
                service.setDescriptionsrv(rs.getString("descriptionsrv"));
                service.setTypesrv(rs.getString("typesrv"));
                service.setCostsrv(rs.getDouble("costsrv"));
                service.setTimesrv(rs.getString("timesrv"));

                list_All.add(service);
                //tv_all_list.getItems().add(service);
            }
            //tv_all_list.getItems().clear();
            //v_all_list.getItems().addAll(list_All);
            con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
    public void caclTotal() {
        Double sum = 0.0;
        for (Service serv: list_Cur)
             {
                 sum += serv.getCostsrv();
             }
        l_c_price.setText(""+sum);
        l_c_services.setText(""+tv_cur_list.getItems().size());
    }
    public void removeUsed() {
        Double sum = 0.0;
        for (Service serv: list_Cur)
             {
                 sum += serv.getCostsrv();
             }
        l_c_price.setText(""+sum);
    }
    public void configureChanges() {
        try {
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            // ResultSet rs = st.executeQuery("SELECT id_order, order_date, phone_number, address, id_client, id_master, id_phone, id_order_status, description, comments, name_model FROM orders_view");
            PreparedStatement ps = con.prepareStatement("DELETE FROM on_order_srv WHERE id_order_forservice = ? " );
            ps.setInt(1, _Order.getId_order());
            ps.executeUpdate();

            ps = con.prepareStatement("INSERT INTO on_order_srv (id_order_forservice, id_srv_onlist) VALUES (?,?)" );
            for (Service service : list_Cur) {
                ps.setInt(1, _Order.getId_order());
                ps.setInt(2, service.getId_service());
                ps.executeUpdate();
            }
            caclTotal();
            con.close();
        } catch (SQLException e) {
            {
                e.printStackTrace();
            }
        }
    }
}

