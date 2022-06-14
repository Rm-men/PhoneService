package web.master.entity;

public class Order {
    public String contacts;
    private Integer id_order;
    private String dateord;
    private String phonenumber;
    private String namecl;
    private String family;
    private String patronymic;
    private String address;
    private Integer id_client;
    private Integer id_master;
    private Integer id_phone;
    private String namephone;
    private String id_order_status;
    private String descriptionos;
    private String descriptionord;
    private String comments;

    private String services;
    private String components;


    public Order(){}
    public Order(Integer id_order, String order_date, String phone_number, String address, Integer id_client, Integer id_master, Integer id_phone, String id_order_status, String descriptionos, String description, String comments){
        this.id_order = id_order;
        this.dateord = order_date;
        this. phonenumber = phone_number;
        this.address = address;
        this.id_client = id_client;
        this.id_master = id_master;
        this.id_phone = id_phone;
        this.id_order_status = id_order_status;
        this.descriptionos = descriptionos;
        this.descriptionord = description;
        this.comments = comments;
    }
    public void setContacts(String family, String namecl, String patronymic, String phonenumber) {
        if (patronymic == null) patronymic = "";
                else patronymic = " "+patronymic;
        this.contacts =  family+" "+ namecl + patronymic + " " + phonenumber;
    }
    public String getContacts() {
        return contacts;
    }

    public Integer getId_order() {
        return id_order;
    }

    public void setId_order(Integer id_order) {
        this.id_order = id_order;
    }

    public String getDateord() {
        return dateord;
    }

    public void setDateord(String dateord) {
        this.dateord = dateord;
    }

    public String getPhone_number() {
        return phonenumber;
    }

    public void setPhone_number(String phone_number) {
        this.phonenumber = phone_number;
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

    public String getDescriptionord() {
        return descriptionord;
    }

    public void setDescriptionord(String descriptionord) {
        this.descriptionord = descriptionord;
    }

    public String getComments() {
        return comments;
    }

    public void setComments(String comments) {
        this.comments = comments;
    }

    public String getDescriptionos() {
        return descriptionos;
    }

    public void setDescriptionos(String descriptionos) {
        this.descriptionos = descriptionos;
    }

    public String getNamecl() {
        return namecl;
    }

    public void setNamecl(String namecl) {
        this.namecl = namecl;
    }

    public String getFamily() {
        return family;
    }

    public void setFamily(String family) {
        this.family = family;
    }

    public String getPatronymic() {
        return patronymic;
    }

    public void setPatronymic(String patronymic) {
        this.patronymic = patronymic;
    }

    public String getNamephone() {
        return namephone;
    }

    public void setNamephone(String namephone) {
        this.namephone = namephone;
    }

    public String getServices() {
        return services;
    }

    public void addServices(String services) {
        this.services += services;
    }

    public String getComponents() {
        return components;
    }

    public void addComponents(String components) {
        this.components += components+", " ;
    }
}
