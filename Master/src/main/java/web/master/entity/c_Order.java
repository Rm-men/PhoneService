package web.master.entity;

import java.util.Date;

public class c_Order {
    private Integer id_order;
    private String order_date  ;
    private String phone_number;
    private String address;
    private Integer id_client;
    private Integer id_master;
    private Integer id_phone;
    private String name_model;
    private String id_order_status;
    private String description;
    private String comments;

    public c_Order(){}
    public c_Order (Integer id_order, String order_date, String phone_number, String address, Integer id_client, Integer id_master, Integer id_phone, String id_order_status, String description, String  comments){
        this.id_order = id_order;
        this.order_date = order_date;
        this. phone_number = phone_number;
        this.address = address;
        this.id_client = id_client;
        this.id_master = id_master;
        this.id_phone = id_phone;
        this.id_order_status = id_order_status;
        this.description = description;
        this.comments = comments;
    }

    public Integer getId_order() {
        return id_order;
    }

    public void setId_order(Integer id_order) {
        this.id_order = id_order;
    }

    public String getOrder_date() {
        return order_date;
    }

    public void setOrder_date(String order_date) {
        this.order_date = order_date;
    }

    public String getPhone_number() {
        return phone_number;
    }

    public void setPhone_number(String phone_number) {
        this.phone_number = phone_number;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public Integer getId_client() {
        return id_client;
    }

    public void setId_client(Integer id_client) {
        this.id_client = id_client;
    }

    public String getId_order_status() {
        return id_order_status;
    }

    public void setId_order_status(String id_order_status) {
        this.id_order_status = id_order_status;
    }

    public Integer getId_master() {
        return id_master;
    }

    public void setId_master(Integer id_master) {
        this.id_master = id_master;
    }

    public Integer getId_phone() {
        return id_phone;
    }

    public void setId_phone(Integer id_phone) {
        this.id_phone = id_phone;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getComments() {
        return comments;
    }

    public void setComments(String comments) {
        this.comments = comments;
    }

    public String getNamePhone() {
        return name_model;
    }

    public void setNamePhone(String phone) {
        this.name_model = phone;
    }
}
