package web.master;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.TextArea;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;
import web.master.entity.Employee;
import web.master.entity.Order;

import java.io.IOException;
import java.net.URL;
import java.sql.*;
import java.util.ResourceBundle;

public class ControllerServicesComponents implements Initializable {
    private static Connection con;
    @FXML public Button b_ch_services;
    @FXML public Button b_ch_components;
    @FXML public ComboBox cb_status;
    @FXML public Label l_phone;
    @FXML public TextArea ta_description;
    @FXML public TextArea ta_comments;
    @FXML public TextArea ta_contacts;
    @FXML public TextArea ta_services;
    @FXML public TextArea ta_components;
    private ObservableList<String> statusList = FXCollections.observableArrayList();

    public Employee _Employee; // private
    public Order _Order;

    public ControllerServicesComponents(Employee cEmployee, Order order)
    {
        _Employee = cEmployee;
        _Order = order;
    };

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        Conn с = new Conn();
        con = с.getConnect();

        statusList = getStatusList();
        cb_status.getItems().addAll(statusList);
        // l_date.setText(_Order.getOrder_date());
        // l_phone.setText(_Order.getNamePhone());
        ta_description.setText(_Order.getDescriptionord());
        b_ch_services.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                System.out.println("Click to change services");
                Stage newWindow = new Stage();
                FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("Order_info_picked.fxml"));
                // fxmlLoader.setController( new ControllerActiveOrder_picked(_Employee, order));
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
        });
        b_ch_components.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                System.out.println("Click to change components");
            }
        });
    }
    public static ObservableList<String> getStatusList() {
        ObservableList<String> list = FXCollections.observableArrayList();
        try {
            // con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("Select descriptionos From order_status");
            while (rs.next()) {
                String stat = rs.getString("description_order_status");
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
}

