package web.master;

import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.*;
import javafx.scene.input.MouseEvent;
import web.master.entity.c_Employee;
import web.master.entity.c_Order;

import java.net.URL;
import java.sql.*;
import java.util.ResourceBundle;

public class ControllerFreeOrder_no_picked implements Initializable {
    private Connection con;
    @FXML public Button b_accept;
    @FXML public Label l_date;
    @FXML public TextArea ta_phone;
    @FXML public TextArea ta_description;


    public c_Employee _Employee; // private
    public c_Order _Order;

    public ControllerFreeOrder_no_picked(c_Employee cEmployee, c_Order order)
    {
        _Employee = cEmployee;
        _Order = order;
    };

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        l_date.setText(_Order.getOrder_date());
        ta_phone.setText(_Order.getNamePhone());
        ta_description.setText(_Order.getDescription());
        b_accept.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                System.out.println("Заказ принят");
            }
        });
    }
    private void initData() {
        try {
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT id_order, order_date, phone_number, address, id_client, id_master, id_phone, id_order_status, description, comments FROM orders_view");
            while (rs.next()) {
                c_Order order = new c_Order();
                order.setId_order(rs.getInt("id_order"));
                order.setOrder_date(rs.getDate("order_date").toString());
                order.setPhone_number(rs.getString("phone_number"));
                order.setAddress(rs.getString("address"));
                order.setId_client(rs.getInt("id_client"));
                order.setId_master(rs.getInt("id_master"));
                order.setId_phone(rs.getInt("id_phone"));
                order.setId_order_status(rs.getString("id_order_status"));
                order.setDescription(rs.getString("description"));
                order.setComments(rs.getString("comments"));

            }
        } catch (SQLException e) {
            {
                e.printStackTrace();
            }
        }
    }
}

