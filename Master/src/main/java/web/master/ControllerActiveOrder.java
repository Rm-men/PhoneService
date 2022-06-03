package web.master;

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
import web.master.entity.Employee;
import web.master.entity.Order;

import java.io.IOException;
import java.net.URL;
import java.sql.*;
import java.util.ResourceBundle;

public class ControllerActiveOrder implements Initializable {
    private Connection con;
    @FXML private TableView<Order> tv_Orders;
    @FXML public Button b_freeOrder;
    @FXML public Button b_activeOrder;
    @FXML public Button b_listStaff;
    @FXML public Button b_listServices;
    @FXML public Label l_username;
    @FXML private ObservableList<Order> OrdersData = FXCollections.observableArrayList();
    @FXML private TableColumn<Order, String> col_phone;
    @FXML private TableColumn<Order, String> col_description;
    @FXML private TableColumn<Order, String> col_comments;
    @FXML private TableColumn<Order, String> col_services;
    @FXML private TableColumn<Order, String> col_components;
    @FXML private TableColumn<Order, String> col_contacts;
    @FXML private TableColumn<Order, String> col_status;
    @FXML private TableColumn<Order, String> col_date;

    public Employee _Employee; // private

    public ControllerActiveOrder(Employee cEmployee) { _Employee = cEmployee;  };

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        l_username.setText(_Employee.getName());
        b_freeOrder.setStyle("-fx-background-color: #8d94d8; -fx-border-width: 5px;");
        b_freeOrder.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                Stage stage_c = (Stage) b_freeOrder.getScene().getWindow();
                stage_c.close();
                System.out.println("Pressed goToFreeorder.");
                Stage newWindow = new Stage();
                FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("main_freeorder.fxml"));
                fxmlLoader.setController( new ControllerActiveOrder(_Employee));
                Scene scene = null;
                try {
                    scene = new Scene(fxmlLoader.load());
                } catch (IOException e) {
                    e.printStackTrace();
                }
                newWindow.setTitle("Мастерская - свободные заказы");
                newWindow.setScene(scene);
                newWindow.setMaximized(true);
                newWindow.show();


            }
        });
        b_activeOrder.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                Stage stage_c = (Stage) b_activeOrder.getScene().getWindow();
                stage_c.close();
                System.out.println("Pressed goToActiveorder.");
                Stage newWindow = new Stage();
                FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("main_activeorder.fxml"));
                fxmlLoader.setController( new ControllerActiveOrder(_Employee));
                Scene scene = null;
                try {
                    scene = new Scene(fxmlLoader.load());
                } catch (IOException e) {
                    e.printStackTrace();
                }
                newWindow.setTitle("Мастерская - активные заказы");
                newWindow.setScene(scene);
                newWindow.setMaximized(true);
                newWindow.show();
            }
        });
        b_listStaff.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                Stage stage_c = (Stage) b_listStaff.getScene().getWindow();
                stage_c.close();
                System.out.println("Pressed goToActiveorder.");
                Stage newWindow = new Stage();
                FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("main_stafflist.fxml"));
                fxmlLoader.setController( new ControllerStaffList(_Employee));
                Scene scene = null;
                try {
                    scene = new Scene(fxmlLoader.load());
                } catch (IOException e) {
                    e.printStackTrace();
                }
                newWindow.setTitle("Мастерская - список товаров");
                newWindow.setScene(scene);
                newWindow.setMaximized(true);
                newWindow.show();
            }
        });
        b_listServices.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                Stage stage_c = (Stage) b_listServices.getScene().getWindow();
                stage_c.close();
                System.out.println("Pressed goToActiveorder.");
                Stage newWindow = new Stage();
                FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("main_serviceslist.fxml"));
                fxmlLoader.setController( new ControllerServiceList(_Employee));
                Scene scene = null;
                try {
                    scene = new Scene(fxmlLoader.load());
                } catch (IOException e) {
                    e.printStackTrace();
                }
                newWindow.setTitle("Мастерская - список услуг");
                newWindow.setScene(scene);
                newWindow.setMaximized(true);
                newWindow.show();
            }
        });

        initData();

        col_phone.setCellValueFactory(new PropertyValueFactory<Order, String>("namephone"));
        col_description.setCellValueFactory(new PropertyValueFactory<Order, String>("descriptionord"));
        col_comments.setCellValueFactory(new PropertyValueFactory<Order, String>("comments"));
        //col_services.setCellValueFactory(new PropertyValueFactory<c_Order, String>(""));
        //col_components.setCellValueFactory(new PropertyValueFactory<c_Order, String>(""));
        col_contacts.setCellValueFactory(new PropertyValueFactory<Order, String>("contacts"));
        col_status.setCellValueFactory(new PropertyValueFactory<Order, String>("descriptionos"));
        //col_status.setCellValueFactory(col_status -> col_status.se(true));
        col_date.setCellValueFactory(new PropertyValueFactory<Order, String>("dateord"));

        tv_Orders.setItems(OrdersData);

        tv_Orders.setRowFactory(rv -> {
            TableRow<Order> row = new TableRow();
            row.setOnMouseClicked(mouseEvent -> {
                Order order = row.getItem();
                try {
                    rowClick(order);
                } catch (IOException e) {
                    e.printStackTrace();
                }
            });
            return row;
        });
    }
    private void initData() {
        try {
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT * FROM orders_view WHERE id_master = "+_Employee.getId()+";");

            while (rs.next()) {
                Order order = new Order();
                order.setId_order(rs.getInt("id_order"));
                order.setDateord(rs.getDate("dateord").toString());
                order.setPhone_number(rs.getString("phonenumber"));
                order.setAddress(rs.getString("address"));
                order.setId_client(rs.getInt("id_client"));
                order.setId_master(rs.getInt("id_master"));
                order.setId_phone(rs.getInt("id_phone"));
                order.setId_order_status(rs.getString("id_order_status"));
                order.setDescriptionord(rs.getString("descriptionord"));
                order.setDescriptionos(rs.getString("descriptionos"));
                order.setComments(rs.getString("comments"));
                order.setNamePhone(rs.getString("namephone"));
                order.setNamecl(rs.getString("namecl"));
                order.setNamecl(rs.getString("patronymic"));
                order.setNamecl(rs.getString("family"));
                order.setContacts(rs.getString("family"), rs.getString("namecl"), rs.getString("patronymic"), rs.getString("phonenumber"));

                OrdersData.add(order);
                con.close();
            }
        } catch (SQLException e) {
            {
                e.printStackTrace();
            }
        }
    }
    public void rowClick(Order order) throws IOException{
        System.out.println("click on active: "+order.getId_client()+", "+ order.getDescriptionord());
        Stage newWindow = new Stage();
        FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("Order_info_picked.fxml"));
        fxmlLoader.setController( new ControllerActiveOrder_picked(_Employee, order));
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

}

// добавить местоположение устройства в фреордер
