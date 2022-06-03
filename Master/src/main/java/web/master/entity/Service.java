package web.master.entity;

import java.math.BigDecimal;

public class Service {
    private Integer id_service;
    private String namesrv;
    private String typesrv;
    private String descriptionsrv;
    private Double costsrv;
    private String timesrv;
    public Service(){}

    public Service(Integer id_service, String name, String type, String description,Double price, String time){
        this.id_service = id_service;
        this.namesrv = name;
        this.typesrv = type;
        this.descriptionsrv = description;
        this.costsrv = price;
        this.timesrv = time;
    }


    public Integer getId_service() {
        return id_service;
    }

    public void setId_service(Integer id_service) {
        this.id_service = id_service;
    }

    public String getNamesrv() {
        return namesrv;
    }

    public void setNamesrv(String namesrv) {
        this.namesrv = namesrv;
    }

    public String getTypesrv() {
        return typesrv;
    }

    public void setTypesrv(String typesrv) {
        this.typesrv = typesrv;
    }

    public String getDescriptionsrv() {
        return descriptionsrv;
    }

    public void setDescriptionsrv(String descriptionsrv) {
        this.descriptionsrv = descriptionsrv;
    }

    public String getTimesrv() {
        return timesrv;
    }

    public void setTimesrv(String timesrv) {
        this.timesrv = timesrv;
    }

    public Double getCostsrv() {
        return costsrv;
    }

    public void setCostsrv(Double costsrv) {
        this.costsrv = costsrv;
    }
}
