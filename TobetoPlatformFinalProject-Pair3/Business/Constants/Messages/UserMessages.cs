namespace Business.Constants;

public class UserMessages
{
    public static string UserNotExist = "Kullanıcı bulunamadı.";
    public static string UserAlreadyExists ="Kayıtlı Kullanıcı.";
    public static string UserMailAlreadyExists = "Kayıtlı mail adresi.";
    public static string UserMailNotExists = "Mail kayıtlı değil."; 
    
    public static string PasswordError = "Şifre Hatalı.";
    public static string PasswordDontMatch = "Şifre eşleşmemektedir.";
    
    public static string MustContainAtMinTwoChar = "En az 2 karakter olmalıdır.";
    public static string MustContainAtMaxTenChar = "En fazla 10 karakter olmalıdır.";
    
    public static string PleaseEnterAStrongerPassword = "Daha güçlü bir şifre giriniz.";
    public static string PleaseEnterAValidNationalityIdNumber = "Lütfen geçerli bir kimlik numarası giriniz.";
    
    public static string Success ="Giriş Başarılı.";
    public static string AuthorizationDenied="Yetki verilme reddedildi.";
}