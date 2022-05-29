package web.master;

import javafx.beans.property.StringProperty;

import java.util.Date;

public class c_Employee {
    private String id_employment_contract;
    private String passport_serial;
    private String passport_number;
    private String address;
    private String id_employee_type;
    private String phone;
    private Date date_of_employment;
    private String name_workshop;
    private String family;
    private String name;
    private String patronymic;
    private String login;
    private String password;

    public c_Employee(Integer id, String id_employment_contract, String passport_serial, String passport_number, String address, String id_employee_type, String phone, Date date_of_employment, String name_workshop, String family, String name, String patronymic, String login, String password) {
        this.id_employment_contract = id_employment_contract;
        this.passport_serial = passport_serial;
        this.passport_number = passport_number;
        this.address = address;
        this.id_employee_type = id_employee_type;
        this.phone = phone;
        this.date_of_employment = date_of_employment;
        this.name_workshop = name_workshop;
        this.family = family;
        this.name = name;
        this.patronymic = patronymic;
        this.login = login;
        this.password = password;
    }

    public String getId_employment_contract() {
        return id_employment_contract;
    }

    public void setId_employment_contract(String id_employment_contract) {
        this.id_employment_contract = id_employment_contract;
    }

    public String getPassport_serial() {
        return passport_serial;
    }

    public void setPassport_serial(String passport_serial) {
        this.passport_serial = passport_serial;
    }

    public String getPassport_number() {
        return passport_number;
    }

    public void setPassport_number(String passport_number) {
        this.passport_number = passport_number;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getId_employee_type() {
        return id_employee_type;
    }

    public void setId_employee_type(String id_employee_type) {
        this.id_employee_type = id_employee_type;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public Date getDate_of_employment() {
        return date_of_employment;
    }

    public void setDate_of_employment(Date date_of_employment) {
        this.date_of_employment = date_of_employment;
    }

    public String getName_workshop() {
        return name_workshop;
    }

    public void setName_workshop(String name_workshop) {
        this.name_workshop = name_workshop;
    }

    public String getFamily() {
        return family;
    }

    public void setFamily(String family) {
        this.family = family;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPatronymic() {
        return patronymic;
    }

    public void setPatronymic(String patronymic) {
        this.patronymic = patronymic;
    }

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}