using System.Linq;
using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;

namespace Bm2s.Data.Common.Services.Partner.PartnerContact
{
  class PartnerContactsService : Service
  {
    public object Get(PartnerContacts request)
    {
      PartnerContactsResponse response = new PartnerContactsResponse();

      if (!request.Ids.Any())
      {
        response.PartnerContacts.AddRange(Datas.Instance.DataStorage.PartnerContacts);
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
