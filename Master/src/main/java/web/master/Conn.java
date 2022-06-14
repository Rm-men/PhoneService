package web.master;

import java.sql.Connection;

public class Conn {

    static Connection con;

        public void setConnect(Connection conect){
            con = conect;
        }
        public Connection getConnect(){
            return con;
        }

}
