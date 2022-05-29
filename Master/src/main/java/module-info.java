module web.master {
    requires javafx.controls;
    requires javafx.fxml;

    requires org.kordamp.bootstrapfx.core;
    requires java.sql;

    opens web.master to javafx.fxml;
    exports web.master;
}