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
import web.master.Conn;
import web.master.MainStart;
import web.master.entity.Component;
import web.master.entity.Employee;
import web.master.entity.Order;
import web.master.entity.Service;
import web.master.mains.ControllerActiveOrder;

import java.io.IOException;
import java.net.URL;
import java.sql.*;
import java.util.Objects;
import java.util.ResourceBundle;

public class Controller_Components implements Initializable {
    private Connection con;
    @FXML public Button b_config;
    @FXML public ComboBox cb_category;
    @FXML public Label l_c_services;
    @FXML public Label l_c_price;

    @FXML public TableView tv_all_list;
    private ObservableList<Component> list_All = FXCollections.observableArrayList(); // список компонентов, доступных для выбора
    @FXML private TableColumn<Component, String>  col_all_name;
    @FXML private TableColumn<Component, String>  col_all_type;
    @FXML private TableColumn<Component, Integer> col_all_garanty;
    @FXML private TableColumn<Component, String>  col_all_manufacturer;
    @FXML private TableColumn<Component, Double>  col_all_cost;

    @FXML public TableView tv_cur_list;
    private ObservableList<Component> list_Cur = FXCollections.observableArrayList(); // список выбранных компонентов для заказа
    @FXML private TableColumn<Component, String>  col_cur_name;
    @FXML private TableColumn<Component, String>  col_cur_type;
    @FXML private TableColumn<Component, Integer> col_cur_garanty;
    @FXML private TableColumn<Component, String>  col_cur_manufacturer;
    @FXML private TableColumn<Component, Double>  col_cur_cost;

    @FXML private ObservableList<Component> list_Components = FXCollections.observableArrayList(); // общий список всех компонентов
    private ObservableList<String> list_Types = FXCollections.observableArrayList();


    public Employee _Employee; // private
    public Order _Order;
    private Stage _stage_detail;
    private Stage _stage_main;


    public Controller_Components(Employee cEmployee, Order order, Stage stage_c, Stage stage_main)
    {
        _Employee = cEmployee;
        _Order = order;
        _stage_detail = stage_c;
        _stage_main = stage_main;
    }

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        cb_category.setPromptText("Без фильтра");
        Conn с = new Conn();
        con = с.getConnect();
/*        try {
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
        } catch (SQLException e) {
            e.printStackTrace();
        }*/
        // list_Types.add("Без фильтра");
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

        col_all_name.setCellValueFactory(new PropertyValueFactory<Component, String>("namecmp"));
        col_all_type.setCellValueFactory(new PropertyValueFactory<Component, String>("typecmp"));
        col_all_garanty.setCellValueFactory(new PropertyValueFactory<Component, Integer>("guarante_period"));
        col_all_manufacturer.setCellValueFactory(new PropertyValueFactory<Component, String>("manufacturercmp_name"));
        col_all_cost.setCellValueFactory(new PropertyValueFactory<Component, Double>("pricecmp"));

        col_cur_name.setCellValueFactory(new PropertyValueFactory<Component, String>("namecmp"));
        col_cur_type.setCellValueFactory(new PropertyValueFactory<Component, String>("typecmp"));
        col_cur_garanty.setCellValueFactory(new PropertyValueFactory<Component, Integer>("guarante_period"));
        col_cur_manufacturer.setCellValueFactory(new PropertyValueFactory<Component, String>("manufacturercmp_name"));
        col_cur_cost.setCellValueFactory(new PropertyValueFactory<Component, Double>("pricecmp"));


        tv_all_list.setItems(list_Components);
        tv_all_list.setRowFactory(rv -> {
            TableRow<Component> row = new TableRow();
            row.setOnMouseClicked(mouseEvent -> {
                Component cmp = row.getItem();
                try {
                    all_rowClick(cmp);
                } catch (IOException e) {
                    e.printStackTrace();
                }
            });
            return row;
        });
        tv_cur_list.setItems(list_Cur);
        tv_cur_list.setRowFactory(rv -> {
            TableRow<Component> row = new TableRow();
            row.setOnMouseClicked(mouseEvent -> {
                Component cmp = row.getItem();
                try {
                    curr_rowClick(cmp);
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
            // con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            // ResultSet rs = st.executeQuery("SELECT id_order, order_date, phone_number, address, id_client, id_master, id_phone, id_order_status, description, comments, name_model FROM orders_view");
            PreparedStatement ps = con.prepareStatement("SELECT * FROM component JOIN manufacturer m on m.id_manufacturer = manufacturercmp JOIN guarantee g on g.id_guarantee = component.id_guaranteecmp WHERE namecmp != 'Без фильтра'");
            ResultSet rs = ps.executeQuery();
            list_Components.clear();
            tv_all_list.getItems().clear();
            while (rs.next()) {
                Component cmp = new Component();
                cmp.setId_component(rs.getInt("id_component"));
                cmp.setNamecmp(rs.getString("namecmp"));
                cmp.setTypecmp(rs.getString("typecmp"));
                cmp.setGuarante_period(rs.getInt("period"));
                cmp.setManufacturercmp_name(rs.getString("name"));
                cmp.setPricecmp(rs.getDouble("pricecmp"));
                list_Components.add(cmp);
                // tv_all_list.getItems().add(cmp);
            }

            ps = con.prepareStatement("SELECT * FROM on_order_cmp JOIN component c on on_order_cmp.id_cmp_onlist = c.id_component JOIN manufacturer m on m.id_manufacturer = c.manufacturercmp JOIN guarantee g on g.id_guarantee = c.id_guaranteecmp WHERE id_order_forcomp = ?");
            ps.setInt(1, _Order.getId_order());
            rs = ps.executeQuery();
            list_Cur.clear();
            while (rs.next()) {
                Component cmp = new Component();
                cmp.setId_component(rs.getInt("id_component"));
                cmp.setNamecmp(rs.getString("namecmp"));
                cmp.setTypecmp(rs.getString("typecmp"));
                cmp.setGuarante_period(rs.getInt("period"));
                cmp.setManufacturercmp_name(rs.getString("name"));
                cmp.setPricecmp(rs.getDouble("pricecmp"));
                list_Cur.add(cmp);
                tv_cur_list.getItems().add(cmp);
            }
            caclTotal();
            rs.close();
            // con.close();
        } catch (SQLException e) {
            {
                e.printStackTrace();
            }
        }
    }
    public void all_rowClick(Component cmp) throws IOException{
        System.out.println("click on all service: "+cmp.getNamecmp());
        list_Cur.add(cmp);
        // tv_cur_list.getItems().add(service);
        tv_cur_list.refresh();
        caclTotal();
    }
    public void curr_rowClick(Component cmp) throws IOException{
        System.out.println("click on curr service: "+cmp.getNamecmp());
        // tv_cur_list.getItems().remove(service);
        list_Cur.remove(cmp);
        caclTotal();
    }
    private ObservableList<String> getTypesList() {
        ObservableList<String> list = FXCollections.observableArrayList();
        try {
            // con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("Select DISTINCT typecmp From component");
            while (rs.next()) {
                String stat = rs.getString("typecmp");
                list.add(stat);
            }
            rs.close();
            st.close();
            // con.close();
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
            list_All.clear();
            String categoty = cb_category.getValue().toString();
            // String categotyOBJ = cb_category.getValue();
            if (Objects.equals(categoty, "Без фильтра")) {
                initData();
                return;
            }

            // con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            // Statement st = con.createStatement();
            // ResultSet rs = st.executeQuery("SELECT id_order, order_date, phone_number, address, id_client, id_master, id_phone, id_order_status, description, comments, name_model FROM orders_view");
            PreparedStatement ps = con.prepareStatement("SELECT * FROM component JOIN manufacturer m on m.id_manufacturer = manufacturercmp JOIN guarantee g on g.id_guarantee = id_guaranteecmp WHERE typecmp = ?");
            ps.setString(1, cb_category.getValue().toString());
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                Component cmp = new Component();
                cmp.setId_component(rs.getInt("id_component"));
                cmp.setNamecmp(rs.getString("namecmp"));
                cmp.setTypecmp(rs.getString("typecmp"));
                cmp.setGuarante_period(rs.getInt("period"));
                cmp.setManufacturercmp_name(rs.getString("name"));
                cmp.setPricecmp(rs.getDouble("pricecmp"));
                list_All.add(cmp);
                tv_all_list.getItems().add(cmp);
            }
            //tv_all_list.getItems().clear();
            //v_all_list.getItems().addAll(list_All);
            // con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
    public void caclTotal() {
        Double sum = 0.0;
        for (Component cmp: list_Cur)
             {
                 sum += cmp.getPricecmp();
             }
        l_c_price.setText(""+sum);
        l_c_services.setText(""+tv_cur_list.getItems().size());
    }
    public void removeUsed() {
        Double sum = 0.0;
        for (Component cmp: list_Cur)
             {
                 sum += cmp.getPricecmp();
             }
        l_c_price.setText(""+sum);
    }
    public void configureChanges() {
        try {
            // con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            // ResultSet rs = st.executeQuery("SELECT id_order, order_date, phone_number, address, id_client, id_master, id_phone, id_order_status, description, comments, name_model FROM orders_view");
            PreparedStatement ps = con.prepareStatement("DELETE FROM on_order_cmp WHERE id_order_forcomp = ? " );
            ps.setInt(1, _Order.getId_order());
            ps.executeUpdate();

            ps = con.prepareStatement("INSERT INTO on_order_cmp (id_order_forcomp, id_cmp_onlist) VALUES (?,?)" );
            for (Component cmp : list_Cur) {
                ps.setInt(1, _Order.getId_order());
                ps.setInt(2, cmp.getId_component());
                ps.executeUpdate();
            }
            caclTotal();
            // con.close();
        } catch (SQLException e) {
            {
                e.printStackTrace();
            }
        }
    }
}

