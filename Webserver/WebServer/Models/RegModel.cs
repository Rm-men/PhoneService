namespace WebServer.Models;

public class RegModel
{
    public string family { get; set; }
    public string name { get; set; }
    public string? patronymic { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public string clpassword { get; set; }


    public static bool Check(RegModel? model)
    {
        bool mdel = model is not null;
        bool mdelem  = string.IsNullOrEmpty(model.email);
        bool mdelpasw = string.IsNullOrEmpty(model.clpassword);
        bool mdelfamily = string.IsNullOrEmpty(model.family);
        bool modname = string.IsNullOrEmpty(model.name);
        bool modnphone =  string.IsNullOrEmpty(model.phone);
        return model is not null && string.IsNullOrEmpty(model.email) && string.IsNullOrEmpty(model.clpassword) &&
               string.IsNullOrEmpty(model.family) && string.IsNullOrEmpty(model.name) &&
               string.IsNullOrEmpty(model.phone);
    }
}
