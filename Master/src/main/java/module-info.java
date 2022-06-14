module web.master {
    requires javafx.controls;
    requires javafx.fxml;

    requires org.kordamp.bootstrapfx.core;
    requires java.sql;

    opens web.master to javafx.fxml;
    exports web.master;
    exports web.master.entity;
    opens web.master.entity to javafx.fxml;
    exports web.master.mains;
    opens web.master.mains to javafx.fxml;
    exports web.master.active_order;
    opens web.master.active_order to javafx.fxml;
    exports web.master.free_order;
    opens web.master.free_order to javafx.fxml;
    exports web.master.trash;
    opens web.master.trash to javafx.fxml;
}