package web.master;

import javafx.event.EventHandler;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;
import web.master.entity.c_Employee;

import java.io.IOException;
import java.net.URL;
import java.sql.*;
import java.util.ResourceBundle;

public class ControllerAuth implements Initializable {

    public TextField Login;
    public Button SignInBtn;
    public PasswordField Password;

    @Override
    public void initialize(URL url, ResourceBundle rb) {

        SignInBtn.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent mouseEvent) {
                Stage newWindow = new Stage();
                Parent root = null;
                try {
                    Connection con = null;
                    try {
                        con = DriverManager.getConnection("jdbc:postgresql://45.10.244.15:55532/work100024", "work100024", "iS~pLC*gmrAgl6aJ1pL7");
                    } catch (SQLException e) {
                        e.printStackTrace();
                    }
                    Connection finalCon = con;
                    assert finalCon != null;

                    PreparedStatement st = finalCon.prepareStatement(
                            "SELECT * FROM employees_view AS ev WHERE ev.login = ? AND ev.password = ?");

                    String login = Login.getText();
                    String enteredPass = Password.getText();
/*
                    byte[] ress = MessageDigest.getInstance("SHA-256").digest(enteredPass.getBytes(StandardCharsets.UTF_8));
                    StringBuilder passBuild = new StringBuilder();
                    for (byte b : ress) {
                        passBuild.append(String.format("%02x", b));
                    }
                    */
                    st.setString(1, login);
                    // st.setString(2, passBuild.toString());
                    st.setString(2, enteredPass);
                    ResultSet rs = st.executeQuery();
                    if(rs.next()){
                        c_Employee emp = new c_Employee();
                        emp.setId(rs.getInt("id"));
                                emp.setId_employment_contract(rs.getString("id_contract"));
                                emp.setPassport_serial(rs.getString("paspserial"));
                                emp.setPassport_number(rs.getString("paspnumber"));
                                emp.setEmp_address(rs.getString("empaddress"));
                                emp.setEmployee_type(rs.getString("type"));
                                emp.setPhone(rs.getString("phone"));
                                emp.setDate_of_employment(rs.getDate("dateemploymentet"));
                                emp.setWs_adress(rs.getString("address"));
                                emp.setFamily(rs.getString("family"));
                                emp.setName(rs.getString("name"));
                                emp.setPatronymic(rs.getString("patronymic"));
                                emp.setLogin(rs.getString("login"));
                                emp.setPassword(rs.getString("password"));
                        openMain(emp);
                        Stage stage = (Stage)SignInBtn.getScene().getWindow();
                        stage.close();
                    }
                    else{
                        Alert alert = new Alert(Alert.AlertType.ERROR);
                        alert.setContentText("Неверный логин или пароль");
                        alert.showAndWait().ifPresent(rt -> {
                            if (rt == ButtonType.OK) {
                                System.out.println("Pressed ок");
                            }
                        });
                    }
                }
                catch (IOException | SQLException e) {
                    {
                        e.printStackTrace();
                    }
                }
            }
        });
    }

    public void openMain(c_Employee cEmployee) throws IOException, SQLException {
        Stage newWindow = new Stage();
        // FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("main.fxml"));
        // fxmlLoader.setController( new ControllerMain(cEmployee));
        FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("main.fxml"));
        fxmlLoader.setController( new ControllerMain(cEmployee));
        Scene scene = new Scene(fxmlLoader.load());
        newWindow.setTitle("Мастерская");
        newWindow.setScene(scene);
        newWindow.setMaximized(true);
        newWindow.show();
    }
}
