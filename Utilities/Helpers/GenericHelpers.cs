using Utilities.Interfaces;
using Microsoft.AspNetCore.Http;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Interfaces.Security;
using Utilities.Interfaces.OthersDates;

namespace Utilities.Helpers
{
    public class GenericHelpers : IGenericIHelpers
    {
        private readonly IDatetimeHelper _datetimeHelper;
        private readonly IPasswordHelper _passwordHelper;
        private readonly IAuthHeaderHelper _authHeaderHelper;
        private readonly IRoleHelper _roleHelper;
        private readonly IUserHelper _userHelper;
        private readonly IValidationHelper _validationHelper;
        private readonly IChangeLogHelper _changeLogHelper;
        private readonly ICityHelper _cityHelper;
        private readonly IClientHelper _clientHelper;
        private readonly ICountryHelper _countryHelper;
        private readonly IPersonHelper _personHelper;
        private readonly INeighborhoodHelper _neighborhoodHelper;
        private readonly IFormHelper _formHelper;
        private readonly IModuleHelper _moduleHelper;
        private readonly IPermissionHelper _permissionHelper;
        private readonly IDepartmentHelper _departmentHelper;
        private readonly IProviderHelper _providerHelper;
        private readonly IEmployeeHelper _employeeHelper;

        public GenericHelpers(
            IDatetimeHelper datetimeHelper,
            IPasswordHelper passwordHelper,
            IAuthHeaderHelper authHeaderHelper,
            IRoleHelper roleHelper,
            IUserHelper userHelper,
            IValidationHelper validationHelper,
            IChangeLogHelper changeLogHelper,
            ICityHelper cityHelper,
            IClientHelper clientHelper,
            ICountryHelper countryHelper,
            IPersonHelper personHelper,
            INeighborhoodHelper neighborhoodHelper,
            IFormHelper formHelper,
            IModuleHelper moduleHelper,
            IPermissionHelper permissionHelper,
            IDepartmentHelper departmentHelper,
            IProviderHelper providerHelper,
            IEmployeeHelper employeeHelper)
        {
            _datetimeHelper = datetimeHelper;
            _passwordHelper = passwordHelper;
            _authHeaderHelper = authHeaderHelper;
            _roleHelper = roleHelper;
            _userHelper = userHelper;
            _validationHelper = validationHelper;
            _changeLogHelper = changeLogHelper;
            _cityHelper = cityHelper;
            _clientHelper = clientHelper;
            _countryHelper = countryHelper;
            _personHelper = personHelper;
            _neighborhoodHelper = neighborhoodHelper;
            _formHelper = formHelper;
            _moduleHelper = moduleHelper;
            _permissionHelper = permissionHelper;
            _departmentHelper = departmentHelper;
            _providerHelper = providerHelper;
            _employeeHelper = employeeHelper;
        }


        public DateTime GetCurrentUtcDateTime() => _datetimeHelper.GetCurrentUtcDateTime();
        public DateTime ConvertToLocalTime(DateTime utcDateTime, string timeZoneId) => _datetimeHelper.ConvertToLocalTime(utcDateTime, timeZoneId);
        public DateTime ConvertToUtc(DateTime localDateTime, string timeZoneId) => _datetimeHelper.ConvertToUtc(localDateTime, timeZoneId);
        public string FormatDateTime(DateTime dateTime, string format = null) => _datetimeHelper.FormatDateTime(dateTime, format);
        public int CalculateAge(DateTime birthDate) => _datetimeHelper.CalculateAge(birthDate);
        public bool IsWeekend(DateTime date) => _datetimeHelper.IsWeekend(date);
        public bool IsBusinessHour(DateTime dateTime, int startHour = 9, int endHour = 17) => _datetimeHelper.IsBusinessHour(dateTime, startHour, endHour);

        public string HashPassword(string password) => _passwordHelper.HashPassword(password);
        public bool VerifyPassword(string hashedPassword, string providedPassword) => _passwordHelper.VerifyPassword(hashedPassword, providedPassword);
        public string GenerateRandomPassword(int length = 12) => _passwordHelper.GenerateRandomPassword(length);

        public string ExtractBearerToken(HttpRequest request) => _authHeaderHelper.ExtractBearerToken(request);
        public (string username, string password) ExtractBasicAuth(HttpRequest request) => _authHeaderHelper.ExtractBasicAuth(request);
        public bool TryGetBearerToken(HttpRequest request, out string token) => _authHeaderHelper.TryGetBearerToken(request, out token);

        public bool HasPermission(IEnumerable<string> userRole, string requiredPermission) => _roleHelper.HasPermission(userRole, requiredPermission);
        public bool IsInRole(IEnumerable<string> userRole, string roleName) => _roleHelper.IsInRole(userRole, roleName);
        public bool HasAnyRole(IEnumerable<string> userRole, IEnumerable<string> requiredRole) => _roleHelper.HasAnyRole(userRole, requiredRole);
        public string GetHighestRole(IEnumerable<string> userRole, IDictionary<string, int> rolePriorities) => _roleHelper.GetHighestRole(userRole, rolePriorities);


        public bool IsValidEmail(string email) => _userHelper.IsValidEmail(email);
        public bool IsValidUsername(string username) => _userHelper.IsValidUsername(username);
        public string NormalizeUsername(string username) => _userHelper.NormalizeUsername(username);


        public bool IsValidPhoneNumber(string phoneNumber) => _validationHelper.IsValidPhoneNumber(phoneNumber);
        public bool IsStrongPassword(string password) => _validationHelper.IsStrongPassword(password);
        public bool IsValidUrl(string url) => _validationHelper.IsValidUrl(url);
        public bool IsValidIp(string ipAddress) => _validationHelper.IsValidIp(ipAddress);
        public bool IsValidCreditCard(string cardNumber) => _validationHelper.IsValidCreditCard(cardNumber);
        public bool IsValidIdentityNumber(string identityNumber) => _validationHelper.IsValidIdentityNumber(identityNumber);
        public Task<ValidationResult> Validate<T>(T dto) => _validationHelper.Validate(dto);


        // Métodos de ICityHelper
        public bool IsValidCityName(string cityName) => _cityHelper.IsValidCityName(cityName);
        public string NormalizeCityName(string cityName) => _cityHelper.NormalizeCityName(cityName);
        public bool IsValidDescription(string description) => _cityHelper.IsValidDescription(description);
        public string NormalizeDescription(string description) => _cityHelper.NormalizeDescription(description);

        // Métodos de IClientHelper
        public bool IsValidClientName(string clientName) => _clientHelper.IsValidClientName(clientName);
        public string NormalizeClientName(string clientName) => _clientHelper.NormalizeClientName(clientName);
        public bool IsValidPhone(string phone) => _clientHelper.IsValidPhone(phone);
        public bool IsValidAddress(string address) => _clientHelper.IsValidAddress(address);
        public string NormalizeAddress(string address) => _clientHelper.NormalizeAddress(address);

      
        // Métodos de ICountryHelper
        public bool IsValidCountryName(string countryName) => _countryHelper.IsValidCountryName(countryName);

        public bool IsValidDeparmentId(int deparmentId)
        {
            throw new NotImplementedException();
        }

        public bool IsValidProviderId(int providerId)
        {
            throw new NotImplementedException();
        }

        public bool IsValidUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public string NormalizeCountryName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsValidCountryCode(string countryCode)
        {
            throw new NotImplementedException();
        }

        public bool IsValidFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public bool IsValidSecondName(string secondName)
        {
            throw new NotImplementedException();
        }

        public bool IsValidFirstLastName(string firstLastName)
        {
            throw new NotImplementedException();
        }

        public bool IsValidSecondLastName(string secondLastName)
        {
            throw new NotImplementedException();
        }

        public string NormalizeName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsValidDireccion(string direccion)
        {
            throw new NotImplementedException();
        }

        public string NormalizeDireccion(string direccion)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPhoneNumber(long phoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool IsValidTypeIdentification(string typeIdentification)
        {
            throw new NotImplementedException();
        }

        public bool IsValidNumberIdentification(long numberIdentification)
        {
            throw new NotImplementedException();
        }

        public bool IsValidNeighborhoodName(string name)
        {
            throw new NotImplementedException();
        }

        public string NormalizeNeighborhoodName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsValidCodePostal(string codePostal)
        {
            throw new NotImplementedException();
        }

        public bool IsValidDistrictName(string districtName)
        {
            throw new NotImplementedException();
        }

        public bool IsValidStreetNumber(string streetNumber)
        {
            throw new NotImplementedException();
        }

        public bool IsValidSecondaryNumber(string secondaryNumber)
        {
            throw new NotImplementedException();
        }

        public bool IsValidTertiaryNumber(string tertiaryNumber)
        {
            throw new NotImplementedException();
        }

        public bool IsValidAdditionalNumber(string additionalNumber)
        {
            throw new NotImplementedException();
        }

        public bool IsValidFormName(string name)
        {
            throw new NotImplementedException();
        }

        public string NormalizeFormName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsValidFormCode(string formCode)
        {
            throw new NotImplementedException();
        }

        public bool IsValidModuleName(string name)
        {
            throw new NotImplementedException();
        }

        public string NormalizeModuleName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsValidModuleCode(string moduleCode)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPermissionName(string name)
        {
            throw new NotImplementedException();
        }

        public string NormalizePermissionName(string name)
        {
            throw new NotImplementedException();
        }

       

        public bool IsValidDepartmentName(string name)
        {
            throw new NotImplementedException();
        }

        public string NormalizeDepartmentName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsValidDepartmentCode(string departmentCode)
        {
            throw new NotImplementedException();
        }

        public bool IsValidCountryId(int countryId)
        {
            throw new NotImplementedException();
        }

        public bool IsValidProviderName(string name)
        {
            throw new NotImplementedException();
        }

        public string NormalizeProviderName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsValidCompanyName(string companyName)
        {
            throw new NotImplementedException();
        }

        public bool IsValidDirection(string direction)
        {
            throw new NotImplementedException();
        }

        public string NormalizeDirection(string direction)
        {
            throw new NotImplementedException();
        }

        public bool IsValidEmployeeName(string name)
        {
            throw new NotImplementedException();
        }

        public string NormalizeEmployeeName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsValidEmployeeCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPosition(string position)
        {
            throw new NotImplementedException();
        }

        public bool IsValidDepartment(string department)
        {
            throw new NotImplementedException();
        }

        public bool IsValidSalary(decimal salary)
        {
            throw new NotImplementedException();
        }

        public bool IsValidContractType(decimal contractType)
        {
            throw new NotImplementedException();
        }

        public bool IsValidWorkSchedule(decimal workSchedule)
        {
            throw new NotImplementedException();
        }

        public bool IsValidHireDate(DateTime hireDate)
        {
            throw new NotImplementedException();
        }

        public bool IsValidTerminationDate(DateTime hireDate, DateTime terminationDate)
        {
            throw new NotImplementedException();
        }

       
    }
}