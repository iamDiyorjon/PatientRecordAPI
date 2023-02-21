using Xeptions;

namespace PatientRecord.Web.Models.Doctors.Exceptions
{
    public class NullDoctorException:Xeption
    {
        public NullDoctorException()
            :base(message:"Doctor is null")
        { }
    }
}
