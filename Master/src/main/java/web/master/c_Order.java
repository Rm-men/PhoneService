package web.master;

import java.util.Date;

public class c_Order {
    private Integer id_order;
    private Date order_date  ;
    private String phone_number;
    private String address;
    private Integer id_client;
    private Integer id_order_status;
    public c_Order(){}
    public c_Order (Integer id_order, Date order_date, String phone_number, String address, Integer id_client, Integer id_order_status){
        this.id_order = id_order;
        this.order_date = order_date;
        this. phone_number = phone_number;
        this.address = address;
        this.id_client = id_client;
        this.id_order_status = id_order_status;
    }

    public Integer getId_order() {
        return id_order;
    }

    public void setId_order(Integer id_order) {
        this.id_order = id_order;
    }

    public Date getOrder_date() {
        return order_date;
    }

    public void setOrder_date(Date order_date) {
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

    public Integer getId_order_status() {
        return id_order_status;
    }

    public void setId_order_status(Integer id_order_status) {
        this.id_order_status = id_order_status;
    }
}
