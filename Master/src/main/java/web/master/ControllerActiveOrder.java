package web.master;

import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;

import java.io.IOException;
import java.net.URL;
import java.sql.Connection;
import java.util.ResourceBundle;

public class ControllerActiveOrder implements Initializable {
    private Connection con;
    @FXML public Button b_freeOrder;
    @FXML public Button b_activeOrder;
    @FXML public Button b_listStaff;
    @FXML public Button b_listServices;
    @FXML public Label l_username;

    public c_Employee _Employee; // private

    public ControllerActiveOrder(c_Employee cEmployee) { _Employee = cEmployee;  };

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        l_username.setText(_Employee.getName());
        b_activeOrder.setStyle("-fx-background-color: #8d94d8; -fx-border-width: 5px;");
        b_freeOrder.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                Stage stage_c = (Stage) b_freeOrder.getScene().getWindow();
                stage_c.close();
                System.out.println("Pressed goToFreeorder.");
                Stage newWindow = new Stage();
                FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("main_freeorder.fxml"));
                fxmlLoader.setController( new ControllerFreeOrder(_Employee));
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
        // initData();
    }

}

