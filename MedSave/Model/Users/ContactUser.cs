namespace MedSave.Model;

public class ContactUser
{
    public long ContactUserId { get; set; }
    public string EmailUser { get; set; }
    public long PhoneNumberUser { get; set; }

    public override string ToString()
    {
        return
            $"{nameof(ContactUserId)}: {ContactUserId}, {nameof(EmailUser)}: {EmailUser}, {nameof(PhoneNumberUser)}: {PhoneNumberUser}";
    }
}