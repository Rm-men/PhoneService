package web.master.entity;

public class Component {
    private Integer id_component;
    private String typecmp;
    private String namecmp;
    private Integer id_guaranteecmp;
    private Integer manufacturercmp;
    private Double pricecmp;
    public Component(){}

    public Integer getId_component() {
        return id_component;
    }

    public void setId_component(Integer id_component) {
        this.id_component = id_component;
    }

    public String getTypecmp() {
        return typecmp;
    }

    public void setTypecmp(String typecmp) {
        this.typecmp = typecmp;
    }

    public String getNamecmp() {
        return namecmp;
    }

    public void setNamecmp(String namecmp) {
        this.namecmp = namecmp;
    }

    public Integer getId_guaranteecmp() {
        return id_guaranteecmp;
    }

    public void setId_guaranteecmp(Integer id_guaranteecmp) {
        this.id_guaranteecmp = id_guaranteecmp;
    }

    public Integer getManufacturercmp() {
        return manufacturercmp;
    }

    public void setManufacturercmp(Integer manufacturercmp) {
        this.manufacturercmp = manufacturercmp;
    }

    public Double getPricecmp() {
        return pricecmp;
    }

    public void setPricecmp(Double pricecmp) {
        this.pricecmp = pricecmp;
    }
}
