using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Partner.PartnerContact
{
  class PartnerContactsService : Service
  {
    public object Get(PartnerContacts request)
    {
      PartnerContactsResponse response = new PartnerContactsResponse();

      if (!request.Ids.Any())
      {
        response.PartnerContacts.AddRange(Datas.Instance.DataStorage.PartnerContacts.Where(item =>
          (string.IsNullOrWhiteSpace(request.Email) || item.Email.ToLower().Contains(request.Email.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.FaxNumber) || item.FaxNumber.ToLower().Contains(request.FaxNumber.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.FirstName) || item.FirstName.ToLower().Contains(request.FirstName.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Function) || item.Function.ToLower().Contains(request.Function.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.LastName) || item.LastName.ToLower().Contains(request.LastName.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.MobilePhoneNumber) || item.MobilePhoneNumber.ToLower().Contains(request.MobilePhoneNumber.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.PhoneNumber) || item.PhoneNumber.ToLower().Contains(request.PhoneNumber.ToLower())) &&
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        response.PartnerContacts.AddRange(Datas.Instance.DataStorage.PartnerContacts.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(PartnerContacts request)
    {
      if (request.PartnerContact.Id > 0)
      {
        Datas.Instance.DataStorage.PartnerContacts[request.PartnerContact.Id] = request.PartnerContact;
      }
      else
      {
        Datas.Instance.DataStorage.PartnerContacts.Add(request.PartnerContact);
      }
      return request.PartnerContact;
    }
  }
}
