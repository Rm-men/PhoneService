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

public class ControllerActiveOrder_picked implements Initializable {
    private static Connection con;
    @FXML public Button b_ch_services;
    @FXML public Button b_ch_components;
    @FXML public Button b_ch_comment;
    @FXML public ComboBox cb_status;
    @FXML public Label l_phone;
    @FXML public Label l_date;
    @FXML public TextArea ta_description;
    @FXML public TextArea ta_comments;
    @FXML public TextArea ta_contacts;
    @FXML public TextArea ta_services;
    @FXML public TextArea ta_components;
    private static ObservableList<String> statusList = FXCollections.observableArrayList();
    private ObservableList<String> idstatusList = FXCollections.observableArrayList();

    private Stage _stage_c;


    public Employee _Employee; // private
    public Order _Order;

    public ControllerActiveOrder_picked(Employee cEmployee, Order order, Stage stage_c)
    {
        _Employee = cEmployee;
        _Order = order;
        _stage_c = stage_c;
    };

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        statusList.clear();
        idstatusList.clear();
        cb_status.getItems().clear();
        getStatusList();
        cb_status.getItems().addAll(statusList);
        cb_status.setValue(_Order.getDescriptionos());
        cb_status.setOnAction(event -> editStatus(cb_status.getValue().toString()));

        l_date.setText(_Order.getDateord());
        l_phone.setText(_Order.getNamephone());
        ta_description.setText(_Order.getDescriptionord());

        ta_comments.setText(_Order.getComments());
        ta_comments.setOnInputMethodTextChanged(event -> editComment(ta_comments.getText()));

        ta_contacts.setText(_Order.getContacts());
        b_ch_services.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                System.out.println("Click to change services");
                Stage newWindow = new Stage();
                FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("ComponentsServices.fxml"));
                fxmlLoader.setController( new Controller_Services(_Employee, _Order));
                Scene scene = null;
                try {
                    scene = new Scene(fxmlLoader.load());
                } catch (IOException e) {
                    e.printStackTrace();
                }
                newWindow.setTitle("Мастерская - выбор компонентов");
                newWindow.setScene(scene);
                newWindow.show();
            }
        });
        b_ch_comment.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                editComment(ta_comments.getText());
            }
        });
        b_ch_components.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                System.out.println("Click to change components");
            }
        });
    }
    public void getStatusList() {
        // ObservableList<String> list = FXCollections.observableArrayList();
        try {
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("Select idos, descriptionos From order_status");
            while (rs.next()) {
                idstatusList.add(rs.getString("idos"));
                statusList.add(rs.getString("descriptionos"));
            }
            rs.close();
            st.close();
            con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        // return list;
    }

    public void editStatus(String descos) {
        try {
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            PreparedStatement ps = con.prepareStatement("SELECT idos FROM order_status WHERE descriptionos = ?;");
            ps.setString(1, descos);
            ResultSet rs = ps.executeQuery();
            String idordst = "null";

            while (rs.next()) {
                idordst = rs.getString("idos");
            }

            ps = con.prepareStatement("UPDATE orders SET id_order_status = ? WHERE id_order = ?;");
            ps.setString(1, idordst);
            ps.setInt(2, _Order.getId_order());
            ps.executeUpdate();
            ps.close();
            con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        {
            Stage stage_c = (Stage) b_ch_comment.getScene().getWindow();
            stage_c.close();
            System.out.println("Pressed goToActiveorder.");
            Stage newWindow = new Stage();
            FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("main_activeorderf.fxml"));
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
        _stage_c.close();
    }
    public void  editComment(String comment) {
        try {
            System.out.print("Comment changed");
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");

            PreparedStatement ps = con.prepareStatement("UPDATE orders SET comments = ? WHERE id_order = ?");
            ps.setString(1, comment);
            ps.setInt(2, _Order.getId_order());
            ps.executeUpdate();
            ps.close();
            con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}

