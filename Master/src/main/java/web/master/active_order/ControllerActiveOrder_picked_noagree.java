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

public class ControllerActiveOrder_picked_noagree implements Initializable {
    private static Connection con;
/*    @FXML public Button b_ch_services;
    @FXML public Button b_ch_components;*/
    @FXML public Button b_ch_comment;
    @FXML public Button b_ch_configure;
    @FXML public ComboBox cb_status;
    @FXML public CheckBox chb_agreement;

    @FXML public Label l_phone;
    @FXML public Label l_date;

/*    @FXML public Label l_total_price;
    @FXML public Label l_service_price;
    @FXML public Label l_components_price;*/


    @FXML public TextArea ta_description;
    @FXML public TextArea ta_comments;
    @FXML public TextArea ta_contacts;
    @FXML public TextArea ta_diagnostic;

    private static ObservableList<String> statusList = FXCollections.observableArrayList();
    private ObservableList<String> idstatusList = FXCollections.observableArrayList();


    private Stage _stage_main;

    public Employee _Employee; // private
    public Order _Order;

    public ControllerActiveOrder_picked_noagree(Employee cEmployee, Order order, Stage stage_main)
    {
        _Employee = cEmployee;
        _Order = order;
        _stage_main = stage_main;
    };

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        // initData();
        Conn с = new Conn();
        con = с.getConnect();
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
        String st = _Order.getDiagnostic();
        ta_diagnostic.setText(_Order.getDiagnostic());


        ta_comments.setText(_Order.getComments());
        ta_comments.setOnInputMethodTextChanged(event -> editComment(ta_comments.getText()));

        ta_contacts.setText(_Order.getContacts());
        b_ch_configure.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
               configDiagnostic();
            }
        });
        b_ch_comment.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                editComment(ta_comments.getText());
            }
        });
         if (!Objects.equals(cb_status.getValue().toString(), "Проводится диагностика"))
         {
             b_ch_configure.setDisable(true);
             ta_diagnostic.setDisable(true);
         }
        if (Objects.equals(_Order.getId_order_status(), "waiting_0"))
        {
/*            b_ch_configure.setDisable(true);
            ta_diagnostic.setDisable(true);*/
            cb_status.setDisable(true);
        }
    }
    public void getStatusList() {
        // ObservableList<String> list = FXCollections.observableArrayList();
        try {
            // con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("Select * From order_status WHERE idos = 'waiting_0' ORDER BY logical_sequence ");
            int agree_step = 0;
            while (rs.next()) {
                agree_step = rs.getInt("logical_sequence");
            }
             rs = st.executeQuery("Select * From order_status ORDER BY logical_sequence");
            if (_Order.getAgreement() == null)
            {
                while (rs.next()) {
                    idstatusList.add(rs.getString("idos"));
                    statusList.add(rs.getString("descriptionos"));
                    if (rs.getInt("logical_sequence") == agree_step) {
                        rs.close();
                        st.close();
                        return;
                    }
                }
                while (rs.next()) {
                    Integer loc_seq = rs.getInt("logical_sequence");
                    if (loc_seq <= agree_step) rs.next();
                    else {
                        idstatusList.add(rs.getString("idos"));
                        statusList.add(rs.getString("descriptionos"));
                    }
                }
            }
            else
            {

            }
            rs.close();
            st.close();
            // con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        // return list;
    }
    public void editStatus(String descos) {
        try {
            // con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            PreparedStatement ps = con.prepareStatement("SELECT idos FROM order_status WHERE descriptionos = ?;");
            ps.setString(1, descos);
            ResultSet rs = ps.executeQuery();
            String idordst = "null";

            while (rs.next()) {
                idordst = rs.getString("idos");
            }
            ps = con.prepareStatement("INSERT INTO story_order_move (idorder, idhuman, idoldstatus, idnewstatus)values (?,?,?,?)");
            ps.setInt(1, _Order.getId_order());
            ps.setInt(2, _Employee.getId());
            ps.setString(3, _Order.getId_order_status());
            ps.setString(4, idordst);
/*            ps.setInt(5, _Order.getId_order());
            ps.setInt(6, _Order.getId_order());*/
            ps.execute();

            ps = con.prepareStatement("UPDATE orders SET id_order_status = ? WHERE id_order = ?;");
            ps.setString(1, idordst);
            ps.setInt(2, _Order.getId_order());
            ps.executeUpdate();

            ps = con.prepareStatement("UPDATE orders SET diagnostic = ? WHERE id_order = ?;");
            ps.setString(1, ta_diagnostic.toString());
            ps.setInt(2, _Order.getId_order());
            ps.executeUpdate();
            ps.close();
            // con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        {
            Stage stage_c = (Stage) b_ch_comment.getScene().getWindow();
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
            //stage_c.close(); //
            newWindow.show(); //

            Stage newWindowO = new Stage();
            FXMLLoader fxmlLoaderO = new FXMLLoader();
            if (_Order.getAgreement()== null){
                fxmlLoaderO = new FXMLLoader(MainStart.class.getResource("Order_info_picked_noagree.fxml"));
                fxmlLoaderO.setController(new ControllerActiveOrder_picked_noagree(_Employee, _Order, stage_c));

            }
            else if (_Order.getAgreement()) {
                fxmlLoaderO = new FXMLLoader(MainStart.class.getResource("Order_info_picked.fxml"));
                fxmlLoaderO.setController( new ControllerActiveOrder_picked(_Employee, _Order, stage_c));
            }
            Scene sceneO = null;
            try {
                sceneO = new Scene(fxmlLoaderO.load());
            } catch (IOException e) {
                e.printStackTrace();
            }
            newWindowO.setTitle("Мастерская - детализация активного заказа");
            //newWindowO.setScene(sceneO);
            newWindow.show(); //
            _stage_main.close();
            newWindowO.show();
            stage_c.close();
        }
    }
    public void configDiagnostic() {
        try {
            // con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            PreparedStatement ps;
            ps = con.prepareStatement("UPDATE orders SET diagnostic = ? WHERE id_order = ?;");
            ps.setString(1, ta_diagnostic.getText());
            ps.setInt(2, _Order.getId_order());
            ps.executeUpdate();

            ps = con.prepareStatement("UPDATE orders SET id_order_status = 'waiting_0' WHERE id_order = ?;");
            ps.setInt(1, _Order.getId_order());
            ps.executeUpdate();
            ps.close();
            // con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        {
            Stage stage_c = (Stage) b_ch_comment.getScene().getWindow();
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
/*
        _stage_main.close();
*/
    }
    public void editComment(String comment) {
        try {
            System.out.print("Comment changed");
            // con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            PreparedStatement ps = con.prepareStatement("UPDATE orders SET comments = ? WHERE id_order = ?");
            ps.setString(1, comment);
            ps.setInt(2, _Order.getId_order());
            ps.executeUpdate();
            ps.close();
            // con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}

