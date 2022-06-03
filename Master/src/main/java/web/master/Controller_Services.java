package web.master;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;
import web.master.entity.Employee;
import web.master.entity.Order;
import web.master.entity.Service;

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
    @FXML public TableView tv_cur_list;
    @FXML private ObservableList<Service> ServicesData = FXCollections.observableArrayList();
    private ObservableList<Service> list_Cur = FXCollections.observableArrayList();
    private ObservableList<Service> list_All = FXCollections.observableArrayList();
    private ObservableList<String> list_Types = FXCollections.observableArrayList();
    @FXML private TableColumn<Service, String>  col_all_name;
    @FXML private TableColumn<Service, String>  col_all_type;
    @FXML private TableColumn<Service, Double>  col_all_cost;
    @FXML private TableColumn<Service, String>  col_all_time;

    @FXML private TableColumn<Service, String>  col_cur_name;
    @FXML private TableColumn<Service, String>  col_cur_type;
    @FXML private TableColumn<Service, Double>  col_cur_cost;
    @FXML private TableColumn<Service, String>  col_cur_time;

    public Employee _Employee; // private
    public Order _Order;

    public Controller_Services(Employee cEmployee, Order order)
    {
        _Employee = cEmployee;
        _Order = order;
    };

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        list_Types = getTypesList();
        cb_category.getItems().addAll(list_Types);
        b_config.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                System.out.println("Click to change services");
                Stage stage_c = (Stage) b_config.getScene().getWindow();
                stage_c.close();
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

        tv_all_list.setItems(ServicesData);

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

                ServicesData.add(service);
            }
            calcTotalSumm();
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
        tv_cur_list.getItems().add(service);
        tv_cur_list.refresh();
        calcCount();
        calcTotalSumm();
    }
    public void curr_rowClick(Service service) throws IOException{
        System.out.println("click on curr service: "+service.getNamesrv());
        tv_cur_list.getItems().remove(service);
        list_Cur.remove(service);
        calcCount();
        calcTotalSumm();
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
            list_Cur.clear();
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
                tv_all_list.getItems().add(service);
            }
            //tv_all_list.getItems().clear();
            //v_all_list.getItems().addAll(list_All);
            con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
    public void calcCount() {
        l_c_services.setText(""+tv_cur_list.getItems().size());
    }
    public void calcTotalSumm() {
        Double sum = 0.0;
        for (Service serv: list_Cur)
             {
                 sum += serv.getCostsrv();
             }
        l_c_price.setText(""+sum);
    }
}

