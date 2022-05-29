package web.master;

import java.math.BigDecimal;
import java.util.Date;

public class c_Service {
    private Integer id_service;
    private String name;
    private String type;
    private String description;
    private BigDecimal min_cost;
    private String min_time;
    public c_Service(){}

    public c_Service(Integer id_service, String name, String type, String description, BigDecimal price, String time){
        this.id_service = id_service;
        this.name = name;
        this.type = type;
        this.description = description;
        this.min_cost = price;
        this.min_time = time;
    }


    public Integer getId_service() {
        return id_service;
    }

    public void setId_service(Integer id_service) {
        this.id_service = id_service;
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

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public BigDecimal getPrice() {
        return min_cost;
    }

    public void setPrice(BigDecimal price) {
        this.min_cost = price;
    }

    public String getTime() {
        return min_time;
    }

    public void setTime(String time) {
        this.min_time = time;
    }
}
