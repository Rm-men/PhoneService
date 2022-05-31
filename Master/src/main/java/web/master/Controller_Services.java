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
import web.master.entity.c_Employee;
import web.master.entity.c_Order;
import web.master.entity.c_Service;

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
    @FXML private ObservableList<c_Service> ServicesData = FXCollections.observableArrayList();
    private ObservableList<c_Service> list_Cur = FXCollections.observableArrayList();
    private ObservableList<c_Service> list_All = FXCollections.observableArrayList();
    private ObservableList<String> list_Types = FXCollections.observableArrayList();
    @FXML private TableColumn<c_Service, String>  col_all_name;
    @FXML private TableColumn<c_Service, String>  col_all_type;
    @FXML private TableColumn<c_Service, String>  col_all_cost;
    @FXML private TableColumn<c_Service, String>  col_all_time;

    @FXML private TableColumn<c_Service, String>  col_cur_name;
    @FXML private TableColumn<c_Service, String>  col_cur_type;
    @FXML private TableColumn<c_Service, String>  col_cur_cost;
    @FXML private TableColumn<c_Service, String>  col_cur_time;

    public c_Employee _Employee; // private
    public c_Order _Order;

    public Controller_Services(c_Employee cEmployee, c_Order order)
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
        col_all_name.setCellValueFactory(new PropertyValueFactory<c_Service, String>("name"));
        col_all_type.setCellValueFactory(new PropertyValueFactory<c_Service, String>("type"));
        col_all_cost.setCellValueFactory(new PropertyValueFactory<c_Service, String>("min_cost"));
        col_all_time.setCellValueFactory(new PropertyValueFactory<c_Service, String>("time"));

        col_cur_name.setCellValueFactory(new PropertyValueFactory<c_Service, String>("name"));
        col_cur_type.setCellValueFactory(new PropertyValueFactory<c_Service, String>("type"));
        col_cur_cost.setCellValueFactory(new PropertyValueFactory<c_Service, String>("min_cost"));
        col_cur_time.setCellValueFactory(new PropertyValueFactory<c_Service, String>("time"));


        tv_all_list.setItems(ServicesData);

        tv_all_list.setRowFactory(rv -> {
            TableRow<c_Service> row = new TableRow();
            row.setOnMouseClicked(mouseEvent -> {
                c_Service service = row.getItem();
                try {
                    all_rowClick(service);
                } catch (IOException e) {
                    e.printStackTrace();
                }
            });
            return row;
        });
        tv_cur_list.setRowFactory(rv -> {
            TableRow<c_Service> row = new TableRow();
            row.setOnMouseClicked(mouseEvent -> {
                c_Service service = row.getItem();
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
                c_Service service = new c_Service();
                service.setId_service(rs.getInt("id"));
                service.setName(rs.getString("name"));
                service.setDescription(rs.getString("description"));
                service.setType(rs.getString("type"));
                service.setPrice(rs.getBigDecimal("min_cost"));
                service.setTime(rs.getString("time"));

                ServicesData.add(service);
            }
        } catch (SQLException e) {
            {
                e.printStackTrace();
            }
        }
    }
    public void all_rowClick(c_Service service) throws IOException{
        System.out.println("click on all service: "+service.getName());
        list_Cur.add(service);
        tv_cur_list.getItems().add(service);
        tv_cur_list.refresh();
        refreshSummary();
    }
    public void curr_rowClick(c_Service service) throws IOException{
        System.out.println("click on curr service: "+service.getName());
        tv_cur_list.getItems().remove(service);
    }
    public static ObservableList<String> getTypesList() {
        ObservableList<String> list = FXCollections.observableArrayList();
        try {
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("Select DISTINCT type From list_sirvices");
            while (rs.next()) {
                String stat = rs.getString("type");
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
            ResultSet rs = st.executeQuery("SELECT * FROM list_sirvices WHERE type = '"+ cb_category.getValue().toString()+"';" );
            while (rs.next()) {
                c_Service service = new c_Service();
                service.setId_service(rs.getInt("id"));
                service.setName(rs.getString("name"));
                service.setDescription(rs.getString("description"));
                service.setType(rs.getString("type"));
                service.setPrice(rs.getBigDecimal("min_cost"));
                service.setTime(rs.getString("time"));

                list_All.add(service);
                tv_all_list.getItems().add(service);
            }
            //tv_all_list.getItems().clear();
            //v_all_list.getItems().addAll(list_All);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
    public void refreshSummary() {
        l_c_services.setText(""+tv_cur_list.getItems().size());
        // l_c_price.setText();
        // l_c_time.setText();
    }
    public void calcTotalSumm() {
        for (c_Service serv: list_Cur)
             {

             }
    }
}

