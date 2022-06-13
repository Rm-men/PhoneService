package web.master.free_order;

import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;
import web.master.MainStart;
import web.master.entity.Employee;
import web.master.entity.Order;
import web.master.mains.ControllerActiveOrder;

import java.io.IOException;
import java.net.URL;
import java.sql.*;
import java.util.ResourceBundle;

public class ControllerFreeOrder_no_picked implements Initializable {
    private Connection con;
    @FXML public Button b_accept;
    @FXML public Label l_date;
    @FXML public TextArea ta_phone;
    @FXML public TextArea ta_description;


    public Employee _Employee; // private
    public Order _Order;
    public Stage _last_stage;

    public ControllerFreeOrder_no_picked(Employee cEmployee, Order order, Stage last_stage)
    {
        _last_stage = last_stage;
        _Employee = cEmployee;
        _Order = order;
    };

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        l_date.setText(_Order.getDateord());
        ta_phone.setText(_Order.getNamephone());
        ta_description.setText(_Order.getDescriptionord());
        b_accept.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                System.out.println("Заказ принят");
                // Stage stage_c = (Stage) b_freeOrder.getScene().getWindow();
                try {
                    con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
                    String sql = "UPDATE orders set id_master = ? WHERE id_order = ?";
                    PreparedStatement ps = con.prepareStatement(sql);
                    ps.setInt(1, _Employee.getId());
                    ps.setInt(2, _Order.getId_order());
                    ps.executeUpdate();
                    ps.close();
                    con.close();
                    Stage stage_c = (Stage) b_accept.getScene().getWindow();
                    stage_c.close();
                    {
                        System.out.println("goToActiveorder.");
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
                } catch (SQLException e) {
                    e.printStackTrace();
                }
                _last_stage.close();
            }
        });
    }
}

