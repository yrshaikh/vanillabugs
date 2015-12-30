using System.Collections.Generic;
using System.Linq;
using Data.Core;
using Data.Core.EntityFramework;

namespace Service.Core
{
    public class MasterService : IMasterService
    {
        private readonly IMasterRepository _masterRepository;
        public MasterService(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        public List<IssueMasterModel> GetIssueStatusList()
        {
            List<IssueStatusMaster> data = _masterRepository.GetIssueStatusList();
            return CustomMapper.Map<IssueStatusMaster, IssueMasterModel>(data).ToList();
        }

        public List<IssueMasterModel> GetIssuePriorityList()
        {
            List<IssuePriorityMaster> data = _masterRepository.GetIssuePriorityList();
            return CustomMapper.Map<IssuePriorityMaster, IssueMasterModel>(data).ToList();
        }

        public List<IssueMasterModel> GetIssueTypeList()
        {
            List<IssueTypeMaster> data = _masterRepository.GetIssueTypeList();
            return CustomMapper.Map<IssueTypeMaster, IssueMasterModel>(data).ToList();
        }
    }
}
