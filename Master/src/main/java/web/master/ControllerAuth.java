package web.master;

import javafx.event.EventHandler;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;

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
                            "SELECT * " +
                            "FROM employee AS e WHERE e.login = ? AND e.password = ?");

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
                        //     public Employee(Integer id,
                        //     String id_contract,
                        //     String passport_serial,
                        //     String passport_number,
                        //     String address,
                        //     String id_employee_type,
                        //     String phone,
                        //     Date date_of_employment,
                        //     String name_workshop,
                        //     String family,
                        //     String name,
                        //     String patronymic,
                        //     String login,
                        //     String password) {
                        c_Employee emp = new c_Employee(
                                rs.getInt("id"),
                                rs.getString("id_contract"),
                                rs.getString("passport_serial"),
                                rs.getString("passport_number"),
                                rs.getString("address"),
                                rs.getString("type"),
                                rs.getString("phone"),
                                rs.getDate("date_of_employment"),
                                rs.getString("name_workshop"),
                                rs.getString("family"),
                                rs.getString("name"),
                                rs.getString("patronymic"),
                                rs.getString("login"),
                                rs.getString("password"));
                        openMain(emp);
                        Stage stage = (Stage)SignInBtn.getScene().getWindow();
                        stage.close();
                    }
                    else{
                        Alert alert = new Alert(Alert.AlertType.ERROR);
                        alert.setContentText("Неверный логин или пароль");
                        alert.showAndWait().ifPresent(rt -> {
                            if (rt == ButtonType.OK) {
                                System.out.println("Pressed OK.");
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
        FXMLLoader fxmlLoader = new FXMLLoader(MainStart.class.getResource("main.fxml"));
        fxmlLoader.setController( new ControllerMain(cEmployee));
        Scene scene = new Scene(fxmlLoader.load());
        newWindow.setTitle("Мастерская");
        newWindow.setScene(scene);
        newWindow.setMaximized(true);
        newWindow.show();
    }
}
