package web.master;

import java.util.Date;

public class c_Component {
    private Integer id;
    private String type;
    private String name;
    private String id_guarantee;
    private String manufacturer;
    private c_Component(){}
    private c_Component( Integer id, String type, String name, String id_guarantee,  String manufacturer){
        this.id =  id;
        this.type = type;
        this.name = name;
        this.id_guarantee = id_guarantee;
        this.manufacturer = manufacturer;
    }

    public String getManufacturer() {
        return manufacturer;
    }

    public void setManufacturer(String manufacturer) {
        this.manufacturer = manufacturer;
    }

    public String getId_guarantee() {
        return id_guarantee;
    }

    public void setId_guarantee(String id_guarantee) {
        this.id_guarantee = id_guarantee;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }
}
