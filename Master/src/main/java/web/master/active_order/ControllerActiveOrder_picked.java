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

public class ControllerActiveOrder_picked implements Initializable {
    private static Connection con;
    @FXML public Button b_ch_services;
    @FXML public Button b_ch_components;
    @FXML public Button b_ch_comment;
    @FXML public ComboBox cb_status;
    @FXML public CheckBox chb_agreement;

    @FXML public Label l_phone;
    @FXML public Label l_date;
    @FXML public Label l_total_price;
    @FXML public Label l_service_price;
    @FXML public Label l_components_price;


    @FXML public TextArea ta_description;
    @FXML public TextArea ta_comments;
    @FXML public TextArea ta_contacts;
    @FXML public TextArea ta_services;
    @FXML public TextArea ta_components;


    @FXML public TableView tv_services;
    private ObservableList<Service> list_CurServices = FXCollections.observableArrayList(); // список выбранных услуг для заказа
    @FXML private TableColumn<Service, String>  col_srv_name;
    @FXML private TableColumn<Service, String>  col_srv_type;
    @FXML private TableColumn<Service, String>  col_srv_descr;
    @FXML private TableColumn<Service, String>  col_srv_time;
    @FXML private TableColumn<Service, Double>  col_srv_cost;

    @FXML public TableView tv_components;
    private ObservableList<Component> list_CurComponents = FXCollections.observableArrayList(); // список выбранных компонентов для заказа
    @FXML private TableColumn<Component, String>  col_cmp_name;
    @FXML private TableColumn<Component, String>  col_cmp_type;
    @FXML private TableColumn<Component, Integer> col_cmp_garanty;
    @FXML private TableColumn<Component, String>  col_cmp_manufacturer;
    @FXML private TableColumn<Component, Double>  col_cmp_price;

    private static ObservableList<String> statusList = FXCollections.observableArrayList();
    private ObservableList<String> idstatusList = FXCollections.observableArrayList();


    private Stage _stage_main;

    public Employee _Employee; // private
    public Order _Order;

    public ControllerActiveOrder_picked(Employee cEmployee, Order order, Stage stage_main)
    {
        _Employee = cEmployee;
        _Order = order;
        _stage_main = stage_main;
    };

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        initData();

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
                Stage stage_c = (Stage) b_ch_comment.getScene().getWindow();
                System.out.println("Click to change services");
                Stage newWindow = new Stage();
                FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("Adding_Services.fxml"));
                fxmlLoader.setController( new Controller_Services(_Employee, _Order, stage_c, _stage_main));
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
                Stage stage_c = (Stage) b_ch_comment.getScene().getWindow();
                System.out.println("Click to change services");
                Stage newWindow = new Stage();
                FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("Adding_Components.fxml"));
                fxmlLoader.setController( new Controller_Components(_Employee, _Order, stage_c, _stage_main));
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

        col_srv_name.setCellValueFactory(new PropertyValueFactory<Service, String>("namesrv"));
        col_srv_type.setCellValueFactory(new PropertyValueFactory<Service, String>("typesrv"));
        col_srv_descr.setCellValueFactory(new PropertyValueFactory<Service, String>("descriptionsrv"));
        col_srv_time.setCellValueFactory(new PropertyValueFactory<Service, String>("timesrv"));
        col_srv_cost.setCellValueFactory(new PropertyValueFactory<Service, Double>("costsrv"));

        col_cmp_name.setCellValueFactory(new PropertyValueFactory<Component, String>("namecmp"));
        col_cmp_type.setCellValueFactory(new PropertyValueFactory<Component, String>("typecmp"));
        col_cmp_garanty.setCellValueFactory(new PropertyValueFactory<Component, Integer>("guarante_period"));
        col_cmp_manufacturer.setCellValueFactory(new PropertyValueFactory<Component, String>("manufacturercmp_name"));
        col_cmp_price.setCellValueFactory(new PropertyValueFactory<Component, Double>("pricecmp"));
        caclTotal();

/*
        // tv_all_list.setItems(list_Services);
/*        tv_components.setRowFactory(rv -> {
            TableRow<Service> row = new TableRow();
            row.setOnMouseClicked(mouseEvent -> {
                Service service = row.getItem();
                try {
                    all_rowClick(service);
                } catch (IOException e) {
                    e.printStackTrace();
                }
            });
            return row;
        });*/
/*        tv_services.setRowFactory(rv -> {
            TableRow<Service> row = new TableRow();
            row.setOnMouseClicked(mouseEvent -> {
                Service service = row.getItem();
                try {
                    curr_rowClick(service);
                } catch (IOException e) {
                    e.printStackTrace();
                }
            });
            return row;
        });*/

    }
    private void initData() {
        try {
            Conn с = new Conn();
            con = с.getConnect();
            boolean agree = !_Order.getAgreement();
                chb_agreement.setSelected(!agree);
                b_ch_components.setDisable(agree);
                b_ch_services.setDisable(agree);
                tv_components.setDisable(agree);
                tv_services.setDisable(agree);

            // con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
            Statement st = con.createStatement();
            // ResultSet rs = st.executeQuery("SELECT id_order, order_date, phone_number, address, id_client, id_master, id_phone, id_order_status, description, comments, name_model FROM orders_view");
            PreparedStatement ps = con.prepareStatement("SELECT * FROM on_order_srv JOIN list_sirvices ls on ls.id = on_order_srv.id_srv_onlist WHERE id_order_forservice = ?");
            ps.setInt(1, _Order.getId_order());
            ResultSet rs= ps.executeQuery();
            while (rs.next()) {
                Service service = new Service();
                service.setId_service(rs.getInt("id"));
                service.setNamesrv(rs.getString("namesrv"));
                service.setDescriptionsrv(rs.getString("descriptionsrv"));
                service.setTypesrv(rs.getString("typesrv"));
                service.setCostsrv(rs.getDouble("costsrv"));
                service.setTimesrv(rs.getString("timesrv"));
                list_CurServices.add(service);
                tv_services.getItems().add(service);
            }

            ps = con.prepareStatement("SELECT * FROM on_order_cmp JOIN component c on on_order_cmp.id_cmp_onlist = c.id_component JOIN manufacturer m on m.id_manufacturer = c.manufacturercmp JOIN guarantee g on g.id_guarantee = c.id_guaranteecmp WHERE id_order_forcomp = ?");
            ps.setInt(1, _Order.getId_order());
            rs = ps.executeQuery();
            while (rs.next()) {
                Component cmp = new Component();
                cmp.setId_component(rs.getInt("id_component"));
                cmp.setNamecmp(rs.getString("namecmp"));
                cmp.setTypecmp(rs.getString("typecmp"));
                cmp.setGuarante_period(rs.getInt("period"));
                cmp.setManufacturercmp_name(rs.getString("name"));
                cmp.setPricecmp(rs.getDouble("pricecmp"));
                list_CurComponents.add(cmp);
                tv_components.getItems().add(cmp);
            }
            rs.close();
            // con.close();
        } catch (SQLException e) {
            {
                e.printStackTrace();
            }
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
            if (!_Order.getAgreement())
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
            }
            else
            {
                while (rs.next()) {
                    Integer loc_seq = rs.getInt("logical_sequence");
                    if (loc_seq <= agree_step) rs.next();
                    else {
                        idstatusList.add(rs.getString("idos"));
                        statusList.add(rs.getString("descriptionos"));
                    }
                }
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
            con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
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
        _stage_main.close();
    }
    public void editComment(String comment) {
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
    public void caclTotal() {
        Double sumC = 0.0;
        Double sumS = 0.0;
        for (Component cmp: list_CurComponents)
        {
            sumC += cmp.getPricecmp();
        }
        for (Service service: list_CurServices)
        {
            sumS += service.getCostsrv();
        }
        l_service_price.setText(""+sumS);
        l_components_price.setText(""+sumC);
        l_total_price.setText(""+(sumC+sumS));
    }
}

