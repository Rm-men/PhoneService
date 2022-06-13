package web.master;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.*;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;
import web.master.entity.Employee;
import web.master.entity.Service;
import web.master.mains.ControllerActiveOrder;

import java.net.URL;
import java.sql.*;
import java.util.ResourceBundle;

public class ControllerActive_Filters implements Initializable {
    private static Connection con;
    @FXML public Button b_confimefilters;
    @FXML public Button b_removeilters;
    @FXML public ComboBox cb_fa_phone;
    @FXML public ComboBox cb_fa_status;
    @FXML public DatePicker dp_ot;
    @FXML public DatePicker dp_do;
    @FXML public TextField tf_fa_contacts;
    @FXML private ObservableList<Service> list_Services = FXCollections.observableArrayList();
    private ObservableList<Service> list_Cur = FXCollections.observableArrayList();
    private ObservableList<String> list_Status = FXCollections.observableArrayList();
    private ObservableList<String> list_PhoneNames = FXCollections.observableArrayList();

    public Employee _Employee; // private
    public ControllerActiveOrder CAO;

    public ControllerActive_Filters(Employee e, ControllerActiveOrder cao)
    {
        CAO = cao;
        _Employee = e;
    }

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        cb_fa_phone.getItems().removeAll();
        cb_fa_status.getItems().removeAll();

        b_confimefilters.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                configureFilters();
                System.out.println("Click to confirme filters");
                Stage stage_c = (Stage) b_confimefilters.getScene().getWindow();
                stage_c.close();
            }
        });
        b_removeilters.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                removeFilters();
                System.out.println("Click to remove filters");
            }
        });
        initDataFiltr();
        cb_fa_phone.getItems().addAll(list_PhoneNames);
        cb_fa_status.getItems().addAll(list_Status);
    }

    public void removeFilters() {
        cb_fa_phone.setValue(null);
        cb_fa_status.setValue(null);
        dp_ot.setValue(null);
        dp_do.setValue(null);
        tf_fa_contacts.setText(null);
    }
    public void configureFilters() {
        CAO.applyFilter(cb_fa_phone.getValue(),cb_fa_status.getValue(),dp_ot.getValue(), dp_do.getValue(), tf_fa_contacts.getText());
    }
    private void initDataFiltr() {
        try {
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            // ResultSet rs = st.executeQuery("SELECT id_order, order_date, phone_number, address, id_client, id_master, id_phone, id_order_status, description, comments, name_model FROM orders_view");
            ResultSet rs = st.executeQuery("SELECT namephone FROM phone_model;" );

            list_PhoneNames.add(null);
            while (rs.next()) {
                list_PhoneNames.add(rs.getString("namephone"));
            }

            list_Status.add(null);
            st = con.createStatement();
            rs = st.executeQuery("SELECT descriptionos FROM order_status;" );
            while (rs.next()) {
                list_Status.add(rs.getString("descriptionos"));
            }
            rs.close();
            st.close();
            con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}

