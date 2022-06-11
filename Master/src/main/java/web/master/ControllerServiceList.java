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
import web.master.entity.Service;

import java.io.IOException;
import java.net.URL;
import java.sql.*;
import java.util.ResourceBundle;

public class ControllerServiceList implements Initializable {
    private Connection con;
    @FXML private TableView<Service> Services;
    @FXML public Button b_freeOrder;
    @FXML public Button b_activeOrder;
    @FXML public Button b_listStaff;
    @FXML public Button b_listServices;
    @FXML public Label l_username;
    @FXML private ObservableList<Service> ServicesData = FXCollections.observableArrayList();
    @FXML private TableColumn<Service, String> col_Service;
    @FXML private TableColumn<Service, String> col_Type;
    @FXML private TableColumn<Service, String> col_Description;
    @FXML private TableColumn<Service, String> col_Price;
    @FXML private TableColumn<Service, String> col_Time;

    public Employee _Employee; // private

    public ControllerServiceList(Employee cEmployee) { _Employee = cEmployee;  };

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        l_username.setText(_Employee.getName());
        b_listServices.setStyle("-fx-background-color: #8d94d8; -fx-border-width: 5px;");
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
        });
        b_listStaff.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                Stage stage_c = (Stage) b_listStaff.getScene().getWindow();
                stage_c.close();
                System.out.println("Pressed goToListStaff.");
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
                System.out.println("Pressed goToListServies.");
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
        // Подгрузка данных с таблицы
        initData();
        // Привязка колонок таблицы
        col_Service.setCellValueFactory(new PropertyValueFactory<Service, String>("namesrv"));
        col_Type.setCellValueFactory(new PropertyValueFactory<Service, String>("typesrv"));
        col_Description.setCellValueFactory(new PropertyValueFactory<Service, String>("descriptionsrv"));
        col_Price.setCellValueFactory(new PropertyValueFactory<Service, String>("costsrv"));
        col_Time.setCellValueFactory(new PropertyValueFactory<Service, String>("timesrv"));
        // Занесение данных в таблицу
        Services.setItems(ServicesData);
        // Событие на клик по объекту
        Services.setRowFactory(rv -> {
            TableRow<Service> row = new TableRow();
            row.setOnMouseClicked(mouseEvent -> {
                Service Service = row.getItem();
                try {
                    rowClick(Service);
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
            ResultSet rs = st.executeQuery("SELECT * FROM list_sirvices;");
            while (rs.next()) {
                Service service = new Service();
                service.setId_service(rs.getInt("id"));
                service.setNamesrv(rs.getString("namesrv"));
                service.setDescriptionsrv(rs.getString("descriptionsrv"));
                service.setTypesrv(rs.getString("typesrv"));
                service.setCostsrv(rs.getDouble("costsrv"));
                service.setTimesrv(rs.getString("timesrv"));

                ServicesData.add(service);
                con.close();
            }
        } catch (SQLException e) {
            {
                e.printStackTrace();
            }
        }
    }
    public void rowClick(Service Service) throws IOException{
        System.out.println("Pressed doubleclick on."+Service.getNamesrv());
        // Открытие нового окошка детализации
    }
}

