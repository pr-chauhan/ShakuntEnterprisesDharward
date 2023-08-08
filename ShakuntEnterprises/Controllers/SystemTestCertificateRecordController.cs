using Microsoft.AspNetCore.Mvc;
using ShakuntEnterprises.Models;
using System.Diagnostics;
using System.Data.Odbc;
using System.Data.Common;
using TallyConnector.Core.Models;
using TallyConnector;
using System.Data;
using ShakuntEnterprises.Models;
using ShakuntEnterprises.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShakuntEnterprises.Comman;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Drawing;

namespace ShakuntEnterprises.Controllers
{
    public class SystemTestCertificateRecordController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShakuntEnterprisesContext _context;
        private CommanClass commanClass;
        private IConfiguration configuration;

        public SystemTestCertificateRecordController(ILogger<HomeController> logger, ShakuntEnterprisesContext enterprisesContext, IConfiguration _configuration)
        {
            _logger = logger;
            _context = enterprisesContext;
            configuration = _configuration;
            commanClass = new CommanClass(enterprisesContext,configuration);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.Modules = commanClass.getModlueList(HttpContext.Session.GetString("lid"));
            ViewBag.Menus = commanClass.getModlueMenuList(HttpContext.Session.GetString("lid"));
            ViewBag.CDT = DateTime.Now.ToString();
            ViewBag.SIZE = commanClass.getAllSizeList();
            ViewBag.TRADE = commanClass.getAllTradeDesignationMasterList().Select(x => new { TradeDesignation = x.TradeDesignation }).Distinct();
        }
        // GET: TestCertificateRecordController
        public async Task<IActionResult> Index()
        {
            var  testCertificateRecordModel = new TestCertificateRecordModel();
            var lstTestCertificateRecord = await _context.TestCertificateRecords.Where(x => x.CertificateType.Equals("System")).ToListAsync();
            //foreach (var lst in lstTestCertificateRecord)
            //{
            //    testCertificateRecordModel.Id = lst.Id;
            //    testCertificateRecordModel.CertificateNo = lst.CertificateNo;
            //}
            return View(lstTestCertificateRecord);
        }

        // GET: TestCertificateRecordController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.TestCertificateRecords == null)
            {
                return NotFound();
            }
            var Data = new TestCertificateRecordModel();
            var testCertificateRecord = await _context.TestCertificateRecords.FindAsync(id);
            if (testCertificateRecord != null)
            {
                Data.CertificateNo = testCertificateRecord.CertificateNo;
                Data.CustomerName = testCertificateRecord.CustomerName;
                Data.IssueDate = testCertificateRecord.IssueDate;
                Data.Quanity = testCertificateRecord.Quanity;
                Data.InvoiceNo = testCertificateRecord.InvoiceNo;
                Data.TradeDesignation = testCertificateRecord.TradeDesignation;
                Data.Size = testCertificateRecord.Size;
                Data.BatchDate = testCertificateRecord.BatchDate;
                Data.BatchNo = testCertificateRecord.BatchNo;
                Data.ManufecturingDate = testCertificateRecord.ManufecturingDate;
                Data.Specification = testCertificateRecord.Specification;
                Data.WeldingProcess = testCertificateRecord.WeldingProcess;
                Data.ShieldingGas = testCertificateRecord.ShieldingGas;
                Data.PreHeatInerpassTemp = testCertificateRecord.PreHeatInerpassTemp;
                Data.Type = testCertificateRecord.Type;
                Data.Apms = testCertificateRecord.Apms;
                Data.FlowRate = testCertificateRecord.FlowRate;
                Data.CurrentPolarity = testCertificateRecord.CurrentPolarity;
                Data.Volts = testCertificateRecord.Volts;
                Data.TravelSpeed = testCertificateRecord.TravelSpeed;
                Data.BaseMetal = testCertificateRecord.BaseMetal;
                Data.ElementMinC = testCertificateRecord.ElementMinC;
                Data.ElementMinSi = testCertificateRecord.ElementMinSi;
                Data.ElementMinMn = testCertificateRecord.ElementMinMn;
                Data.ElementMinP = testCertificateRecord.ElementMinP;
                Data.ElementMinS = testCertificateRecord.ElementMinS;
                Data.ElementMinNi = testCertificateRecord.ElementMinNi;
                Data.ElementMinCr = testCertificateRecord.ElementMinCr;
                Data.ElementMinMo = testCertificateRecord.ElementMinMo;
                Data.ElementMinCu = testCertificateRecord.ElementMinCu;
                Data.ElementMaxC = testCertificateRecord.ElementMaxC;
                Data.ElementMaxSi = testCertificateRecord.ElementMaxSi;
                Data.ElementMaxMn = testCertificateRecord.ElementMaxMn;
                Data.ElementMaxP = testCertificateRecord.ElementMaxP;
                Data.ElementMaxS = testCertificateRecord.ElementMaxS;
                Data.ElementMaxNi = testCertificateRecord.ElementMaxNi;
                Data.ElementMaxCr = testCertificateRecord.ElementMaxCr;
                Data.ElementMaxMo = testCertificateRecord.ElementMaxMo;
                Data.ElementMaxCu = testCertificateRecord.ElementMaxCu;
                //Data.ElementResultC = testCertificateRecord.ElementResultC;
                //Data.ElementResultSi = testCertificateRecord.ElementResultSi;
                //Data.ElementResultMn = testCertificateRecord.ElementResultMn;
                //Data.ElementResultP = testCertificateRecord.ElementResultP;
                //Data.ElementResultS = testCertificateRecord.ElementResultS;
                //Data.ElementResultNi = testCertificateRecord.ElementResultNi;
                //Data.ElementResultCr = testCertificateRecord.ElementResultCr;
                //Data.ElementResultMo = testCertificateRecord.ElementResultMo;
                //Data.ElementResultCu = testCertificateRecord.ElementResultCu;
                Data.TestMinUts = testCertificateRecord.TestMinUts;
                Data.TestMinYs = testCertificateRecord.TestMinYs;
                Data.TestMinElongation = testCertificateRecord.TestMinElongation;
                Data.TestMaxUts = testCertificateRecord.TestMaxUts;
                Data.TestMaxYs = testCertificateRecord.TestMaxYs;
                Data.TestMaxElongation = testCertificateRecord.TestMaxElongation;
                //Data.TestResultUts = testCertificateRecord.TestResultUts;
                //Data.TestResultYs = testCertificateRecord.TestResultYs;
                //Data.TestResultElongation = testCertificateRecord.TestResultElongation;
                Data.TestTemp = testCertificateRecord.TestTemp;
                Data.TestImpectValue = testCertificateRecord.TestImpectValue;
                Data.TestCondition = testCertificateRecord.TestCondition;
                Data.SizeStandardValue = testCertificateRecord.SizeStandardValue;
                Data.SizeActualValue = testCertificateRecord.SizeActualValue;
                Data.CoatingStandardValue = testCertificateRecord.CoatingStandardValue;
                Data.CoatingActualValue = testCertificateRecord.CoatingActualValue;
                Data.UtswireStandardValue = testCertificateRecord.UtswireStandardValue;
                Data.UtswireActualValue = testCertificateRecord.UtswireActualValue;
                Data.CastDiaStandardValue = testCertificateRecord.CastDiaStandardValue;
                Data.CastDiaActualValue = testCertificateRecord.CastDiaActualValue;
                Data.HelixStandardValue = testCertificateRecord.HelixStandardValue;
                Data.HelixActualValue = testCertificateRecord.HelixActualValue;
                Data.OtherTestRadioSpecs = testCertificateRecord.OtherTestRadioSpecs;
                Data.OtherTestFaceBendSpecs = testCertificateRecord.OtherTestFaceBendSpecs;
                Data.OtherTestFilledSpecs = testCertificateRecord.OtherTestFilledSpecs;
                //Data.OtherTestResultRadioSpecs = testCertificateRecord.OtherTestResultRadioSpecs;
                //Data.OtherTestResultFaceBendSpecs = testCertificateRecord.OtherTestResultFaceBendSpecs;
                //Data.OtherTestResultFilledSpecs = testCertificateRecord.OtherTestResultFilledSpecs;
                Data.Remarks = testCertificateRecord.Remarks;
                Data.CertificateType = "System";
                Data.CreatedDate = testCertificateRecord.CreatedDate;
                Data.CreatedBy = testCertificateRecord.CreatedBy;
                Data.ModifiedDate = testCertificateRecord.ModifiedDate;
                Data.ModifiedBy = testCertificateRecord.ModifiedBy;
            }
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // GET: TestCertificateRecordController/Create
        public ActionResult Create()
        {
            ViewBag.CERTINO = commanClass.GenerateNumberSeries("CERTIFICATE");
            return View();
        }

        // POST: TestCertificateRecordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestCertificateRecordModel testCertificateRecord)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Data = new TestCertificateRecord();
                    Data.CertificateNo = testCertificateRecord.CertificateNo;
                    Data.CustomerName = testCertificateRecord.CustomerName;
                    Data.IssueDate = testCertificateRecord.IssueDate;
                    Data.Quanity = testCertificateRecord.Quanity;
                    Data.InvoiceNo = testCertificateRecord.InvoiceNo;
                    Data.TradeDesignation = testCertificateRecord.TradeDesignation;
                    Data.Size = testCertificateRecord.Size;
                    Data.BatchDate = testCertificateRecord.BatchDate;
                    Data.BatchNo = testCertificateRecord.BatchNo;
                    Data.ManufecturingDate = testCertificateRecord.ManufecturingDate;
                    Data.Specification = testCertificateRecord.Specification;
                    Data.WeldingProcess = testCertificateRecord.WeldingProcess;
                    Data.ShieldingGas = testCertificateRecord.ShieldingGas;
                    Data.PreHeatInerpassTemp = testCertificateRecord.PreHeatInerpassTemp;
                    Data.Type = testCertificateRecord.Type;
                    Data.Apms = testCertificateRecord.Apms;
                    Data.FlowRate = testCertificateRecord.FlowRate;
                    Data.CurrentPolarity = testCertificateRecord.CurrentPolarity;
                    Data.Volts = testCertificateRecord.Volts;
                    Data.TravelSpeed = testCertificateRecord.TravelSpeed;
                    Data.BaseMetal = testCertificateRecord.BaseMetal;
                    Data.ElementMinC = testCertificateRecord.ElementMinC;
                    Data.ElementMinSi = testCertificateRecord.ElementMinSi;
                    Data.ElementMinMn = testCertificateRecord.ElementMinMn;
                    Data.ElementMinP = testCertificateRecord.ElementMinP;
                    Data.ElementMinS = testCertificateRecord.ElementMinS;
                    Data.ElementMinNi = testCertificateRecord.ElementMinNi;
                    Data.ElementMinCr = testCertificateRecord.ElementMinCr;
                    Data.ElementMinMo = testCertificateRecord.ElementMinMo;
                    Data.ElementMinCu = testCertificateRecord.ElementMinCu;
                    Data.ElementMaxC = testCertificateRecord.ElementMaxC;
                    Data.ElementMaxSi = testCertificateRecord.ElementMaxSi;
                    Data.ElementMaxMn = testCertificateRecord.ElementMaxMn;
                    Data.ElementMaxP = testCertificateRecord.ElementMaxP;
                    Data.ElementMaxS = testCertificateRecord.ElementMaxS;
                    Data.ElementMaxNi = testCertificateRecord.ElementMaxNi;
                    Data.ElementMaxCr = testCertificateRecord.ElementMaxCr;
                    Data.ElementMaxMo = testCertificateRecord.ElementMaxMo;
                    Data.ElementMaxCu = testCertificateRecord.ElementMaxCu;
                    //Data.ElementResultC = testCertificateRecord.ElementResultC;
                    //Data.ElementResultSi = testCertificateRecord.ElementResultSi;
                    //Data.ElementResultMn = testCertificateRecord.ElementResultMn;
                    //Data.ElementResultP = testCertificateRecord.ElementResultP;
                    //Data.ElementResultS = testCertificateRecord.ElementResultS;
                    //Data.ElementResultNi = testCertificateRecord.ElementResultNi;
                    //Data.ElementResultCr = testCertificateRecord.ElementResultCr;
                    //Data.ElementResultMo = testCertificateRecord.ElementResultMo;
                    //Data.ElementResultCu = testCertificateRecord.ElementResultCu;
                    Data.TestMinUts = testCertificateRecord.TestMinUts;
                    Data.TestMinYs = testCertificateRecord.TestMinYs;
                    Data.TestMinElongation = testCertificateRecord.TestMinElongation;
                    Data.TestMaxUts = testCertificateRecord.TestMaxUts;
                    Data.TestMaxYs = testCertificateRecord.TestMaxYs;
                    Data.TestMaxElongation = testCertificateRecord.TestMaxElongation;
                    //Data.TestResultUts = testCertificateRecord.TestResultUts;
                    //Data.TestResultYs = testCertificateRecord.TestResultYs;
                    //Data.TestResultElongation = testCertificateRecord.TestResultElongation;
                    Data.TestTemp = testCertificateRecord.TestTemp;
                    Data.TestImpectValue = testCertificateRecord.TestImpectValue;
                    Data.TestCondition = testCertificateRecord.TestCondition;
                    Data.SizeStandardValue = testCertificateRecord.SizeStandardValue;
                    Data.SizeActualValue = testCertificateRecord.SizeActualValue;
                    Data.CoatingStandardValue = testCertificateRecord.CoatingStandardValue;
                    Data.CoatingActualValue = testCertificateRecord.CoatingActualValue;
                    Data.UtswireStandardValue = testCertificateRecord.UtswireStandardValue;
                    Data.UtswireActualValue = testCertificateRecord.UtswireActualValue;
                    Data.CastDiaStandardValue = testCertificateRecord.CastDiaStandardValue;
                    Data.CastDiaActualValue = testCertificateRecord.CastDiaActualValue;
                    Data.HelixStandardValue = testCertificateRecord.HelixStandardValue;
                    Data.HelixActualValue = testCertificateRecord.HelixActualValue;
                    Data.OtherTestRadioSpecs = testCertificateRecord.OtherTestRadioSpecs;
                    Data.OtherTestFaceBendSpecs = testCertificateRecord.OtherTestFaceBendSpecs;
                    Data.OtherTestFilledSpecs = testCertificateRecord.OtherTestFilledSpecs;
                    //Data.OtherTestResultRadioSpecs = testCertificateRecord.OtherTestResultRadioSpecs;
                    //Data.OtherTestResultFaceBendSpecs = testCertificateRecord.OtherTestResultFaceBendSpecs;
                    //Data.OtherTestResultFilledSpecs = testCertificateRecord.OtherTestResultFilledSpecs;
                    Data.Remarks = testCertificateRecord.Remarks;
                    Data.CertificateType = "System";
                    Data.CreatedDate = testCertificateRecord.CreatedDate;
                    Data.CreatedBy = testCertificateRecord.CreatedBy;
                    Data.ModifiedDate = testCertificateRecord.ModifiedDate;
                    Data.ModifiedBy = testCertificateRecord.ModifiedBy;
                    _context.Add(Data);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(testCertificateRecord);
            }
            return View(testCertificateRecord);
        }

        // GET: TestCertificateRecordController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TestCertificateRecords == null)
            {
                return NotFound();
            }
            var Data = new TestCertificateRecordModel();
            var testCertificateRecord = await _context.TestCertificateRecords.FindAsync(id);
            if (testCertificateRecord != null)
            {
                Data.CertificateNo = testCertificateRecord.CertificateNo;
                Data.CustomerName = testCertificateRecord.CustomerName;
                Data.IssueDate = testCertificateRecord.IssueDate;
                Data.Quanity = testCertificateRecord.Quanity;
                Data.InvoiceNo = testCertificateRecord.InvoiceNo;
                Data.TradeDesignation = testCertificateRecord.TradeDesignation;
                Data.Size = testCertificateRecord.Size;
                Data.BatchDate = testCertificateRecord.BatchDate;
                Data.BatchNo = testCertificateRecord.BatchNo;
                Data.ManufecturingDate = testCertificateRecord.ManufecturingDate;
                Data.Specification = testCertificateRecord.Specification;
                Data.WeldingProcess = testCertificateRecord.WeldingProcess;
                Data.ShieldingGas = testCertificateRecord.ShieldingGas;
                Data.PreHeatInerpassTemp = testCertificateRecord.PreHeatInerpassTemp;
                Data.Type = testCertificateRecord.Type;
                Data.Apms = testCertificateRecord.Apms;
                Data.FlowRate = testCertificateRecord.FlowRate;
                Data.CurrentPolarity = testCertificateRecord.CurrentPolarity;
                Data.Volts = testCertificateRecord.Volts;
                Data.TravelSpeed = testCertificateRecord.TravelSpeed;
                Data.BaseMetal = testCertificateRecord.BaseMetal;
                Data.ElementMinC = testCertificateRecord.ElementMinC;
                Data.ElementMinSi = testCertificateRecord.ElementMinSi;
                Data.ElementMinMn = testCertificateRecord.ElementMinMn;
                Data.ElementMinP = testCertificateRecord.ElementMinP;
                Data.ElementMinS = testCertificateRecord.ElementMinS;
                Data.ElementMinNi = testCertificateRecord.ElementMinNi;
                Data.ElementMinCr = testCertificateRecord.ElementMinCr;
                Data.ElementMinMo = testCertificateRecord.ElementMinMo;
                Data.ElementMinCu = testCertificateRecord.ElementMinCu;
                Data.ElementMaxC = testCertificateRecord.ElementMaxC;
                Data.ElementMaxSi = testCertificateRecord.ElementMaxSi;
                Data.ElementMaxMn = testCertificateRecord.ElementMaxMn;
                Data.ElementMaxP = testCertificateRecord.ElementMaxP;
                Data.ElementMaxS = testCertificateRecord.ElementMaxS;
                Data.ElementMaxNi = testCertificateRecord.ElementMaxNi;
                Data.ElementMaxCr = testCertificateRecord.ElementMaxCr;
                Data.ElementMaxMo = testCertificateRecord.ElementMaxMo;
                Data.ElementMaxCu = testCertificateRecord.ElementMaxCu;
                //Data.ElementResultC = testCertificateRecord.ElementResultC;
                //Data.ElementResultSi = testCertificateRecord.ElementResultSi;
                //Data.ElementResultMn = testCertificateRecord.ElementResultMn;
                //Data.ElementResultP = testCertificateRecord.ElementResultP;
                //Data.ElementResultS = testCertificateRecord.ElementResultS;
                //Data.ElementResultNi = testCertificateRecord.ElementResultNi;
                //Data.ElementResultCr = testCertificateRecord.ElementResultCr;
                //Data.ElementResultMo = testCertificateRecord.ElementResultMo;
                //Data.ElementResultCu = testCertificateRecord.ElementResultCu;
                Data.TestMinUts = testCertificateRecord.TestMinUts;
                Data.TestMinYs = testCertificateRecord.TestMinYs;
                Data.TestMinElongation = testCertificateRecord.TestMinElongation;
                Data.TestMaxUts = testCertificateRecord.TestMaxUts;
                Data.TestMaxYs = testCertificateRecord.TestMaxYs;
                Data.TestMaxElongation = testCertificateRecord.TestMaxElongation;
                //Data.TestResultUts = testCertificateRecord.TestResultUts;
                //Data.TestResultYs = testCertificateRecord.TestResultYs;
                //Data.TestResultElongation = testCertificateRecord.TestResultElongation;
                Data.TestTemp = testCertificateRecord.TestTemp;
                Data.TestImpectValue = testCertificateRecord.TestImpectValue;
                Data.TestCondition = testCertificateRecord.TestCondition;
                Data.SizeStandardValue = testCertificateRecord.SizeStandardValue;
                Data.SizeActualValue = testCertificateRecord.SizeActualValue;
                Data.CoatingStandardValue = testCertificateRecord.CoatingStandardValue;
                Data.CoatingActualValue = testCertificateRecord.CoatingActualValue;
                Data.UtswireStandardValue = testCertificateRecord.UtswireStandardValue;
                Data.UtswireActualValue = testCertificateRecord.UtswireActualValue;
                Data.CastDiaStandardValue = testCertificateRecord.CastDiaStandardValue;
                Data.CastDiaActualValue = testCertificateRecord.CastDiaActualValue;
                Data.HelixStandardValue = testCertificateRecord.HelixStandardValue;
                Data.HelixActualValue = testCertificateRecord.HelixActualValue;
                Data.OtherTestRadioSpecs = testCertificateRecord.OtherTestRadioSpecs;
                Data.OtherTestFaceBendSpecs = testCertificateRecord.OtherTestFaceBendSpecs;
                Data.OtherTestFilledSpecs = testCertificateRecord.OtherTestFilledSpecs;
                //Data.OtherTestResultRadioSpecs = testCertificateRecord.OtherTestResultRadioSpecs;
                //Data.OtherTestResultFaceBendSpecs = testCertificateRecord.OtherTestResultFaceBendSpecs;
                //Data.OtherTestResultFilledSpecs = testCertificateRecord.OtherTestResultFilledSpecs;
                Data.Remarks = testCertificateRecord.Remarks;
                Data.CertificateType = "System";
                Data.CreatedDate = testCertificateRecord.CreatedDate;
                Data.CreatedBy = testCertificateRecord.CreatedBy;
                Data.ModifiedDate = testCertificateRecord.ModifiedDate;
                Data.ModifiedBy = testCertificateRecord.ModifiedBy;
            }
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        // POST: TestCertificateRecordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, TestCertificateRecordModel testCertificateRecord )
        {
            if (id != testCertificateRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Data = await _context.TestCertificateRecords.FindAsync(id);
                    if(Data != null)
                    {
                        Data.CertificateNo = testCertificateRecord.CertificateNo;
                        Data.CustomerName = testCertificateRecord.CustomerName;
                        Data.IssueDate = testCertificateRecord.IssueDate;
                        Data.Quanity = testCertificateRecord.Quanity;
                        Data.InvoiceNo = testCertificateRecord.InvoiceNo;
                        Data.TradeDesignation = testCertificateRecord.TradeDesignation;
                        Data.Size = testCertificateRecord.Size;
                        Data.BatchDate = testCertificateRecord.BatchDate;
                        Data.BatchNo = testCertificateRecord.BatchNo;
                        Data.ManufecturingDate = testCertificateRecord.ManufecturingDate;
                        Data.Specification = testCertificateRecord.Specification;
                        Data.WeldingProcess = testCertificateRecord.WeldingProcess;
                        Data.ShieldingGas = testCertificateRecord.ShieldingGas;
                        Data.PreHeatInerpassTemp = testCertificateRecord.PreHeatInerpassTemp;
                        Data.Type = testCertificateRecord.Type;
                        Data.Apms = testCertificateRecord.Apms;
                        Data.FlowRate = testCertificateRecord.FlowRate;
                        Data.CurrentPolarity = testCertificateRecord.CurrentPolarity;
                        Data.Volts = testCertificateRecord.Volts;
                        Data.TravelSpeed = testCertificateRecord.TravelSpeed;
                        Data.BaseMetal = testCertificateRecord.BaseMetal;
                        Data.ElementMinC = testCertificateRecord.ElementMinC;
                        Data.ElementMinSi = testCertificateRecord.ElementMinSi;
                        Data.ElementMinMn = testCertificateRecord.ElementMinMn;
                        Data.ElementMinP = testCertificateRecord.ElementMinP;
                        Data.ElementMinS = testCertificateRecord.ElementMinS;
                        Data.ElementMinNi = testCertificateRecord.ElementMinNi;
                        Data.ElementMinCr = testCertificateRecord.ElementMinCr;
                        Data.ElementMinMo = testCertificateRecord.ElementMinMo;
                        Data.ElementMinCu = testCertificateRecord.ElementMinCu;
                        Data.ElementMaxC = testCertificateRecord.ElementMaxC;
                        Data.ElementMaxSi = testCertificateRecord.ElementMaxSi;
                        Data.ElementMaxMn = testCertificateRecord.ElementMaxMn;
                        Data.ElementMaxP = testCertificateRecord.ElementMaxP;
                        Data.ElementMaxS = testCertificateRecord.ElementMaxS;
                        Data.ElementMaxNi = testCertificateRecord.ElementMaxNi;
                        Data.ElementMaxCr = testCertificateRecord.ElementMaxCr;
                        Data.ElementMaxMo = testCertificateRecord.ElementMaxMo;
                        Data.ElementMaxCu = testCertificateRecord.ElementMaxCu;
                        //Data.ElementResultC = testCertificateRecord.ElementResultC;
                        //Data.ElementResultSi = testCertificateRecord.ElementResultSi;
                        //Data.ElementResultMn = testCertificateRecord.ElementResultMn;
                        //Data.ElementResultP = testCertificateRecord.ElementResultP;
                        //Data.ElementResultS = testCertificateRecord.ElementResultS;
                        //Data.ElementResultNi = testCertificateRecord.ElementResultNi;
                        //Data.ElementResultCr = testCertificateRecord.ElementResultCr;
                        //Data.ElementResultMo = testCertificateRecord.ElementResultMo;
                        //Data.ElementResultCu = testCertificateRecord.ElementResultCu;
                        Data.TestMinUts = testCertificateRecord.TestMinUts;
                        Data.TestMinYs = testCertificateRecord.TestMinYs;
                        Data.TestMinElongation = testCertificateRecord.TestMinElongation;
                        Data.TestMaxUts = testCertificateRecord.TestMaxUts;
                        Data.TestMaxYs = testCertificateRecord.TestMaxYs;
                        Data.TestMaxElongation = testCertificateRecord.TestMaxElongation;
                        //Data.TestResultUts = testCertificateRecord.TestResultUts;
                        //Data.TestResultYs = testCertificateRecord.TestResultYs;
                        //Data.TestResultElongation = testCertificateRecord.TestResultElongation;
                        Data.TestTemp = testCertificateRecord.TestTemp;
                        Data.TestImpectValue = testCertificateRecord.TestImpectValue;
                        Data.TestCondition = testCertificateRecord.TestCondition;
                        Data.SizeStandardValue = testCertificateRecord.SizeStandardValue;
                        Data.SizeActualValue = testCertificateRecord.SizeActualValue;
                        Data.CoatingStandardValue = testCertificateRecord.CoatingStandardValue;
                        Data.CoatingActualValue = testCertificateRecord.CoatingActualValue;
                        Data.UtswireStandardValue = testCertificateRecord.UtswireStandardValue;
                        Data.UtswireActualValue = testCertificateRecord.UtswireActualValue;
                        Data.CastDiaStandardValue = testCertificateRecord.CastDiaStandardValue;
                        Data.CastDiaActualValue = testCertificateRecord.CastDiaActualValue;
                        Data.HelixStandardValue = testCertificateRecord.HelixStandardValue;
                        Data.HelixActualValue = testCertificateRecord.HelixActualValue;
                        Data.OtherTestRadioSpecs = testCertificateRecord.OtherTestRadioSpecs;
                        Data.OtherTestFaceBendSpecs = testCertificateRecord.OtherTestFaceBendSpecs;
                        Data.OtherTestFilledSpecs = testCertificateRecord.OtherTestFilledSpecs;
                        //Data.OtherTestResultRadioSpecs = testCertificateRecord.OtherTestResultRadioSpecs;
                        //Data.OtherTestResultFaceBendSpecs = testCertificateRecord.OtherTestResultFaceBendSpecs;
                        //Data.OtherTestResultFilledSpecs = testCertificateRecord.OtherTestResultFilledSpecs;
                        Data.Remarks = testCertificateRecord.Remarks;
                        Data.CertificateType = "System";
                        Data.CreatedDate = testCertificateRecord.CreatedDate;
                        Data.CreatedBy = testCertificateRecord.CreatedBy;
                        Data.ModifiedDate = testCertificateRecord.ModifiedDate;
                        Data.ModifiedBy = testCertificateRecord.ModifiedBy;
                    }
                    _context.Update(Data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestCertificateRecordExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(testCertificateRecord);
        }
        public async Task<IActionResult> UnApprovedCertificateList()
        {
            var testCertificateRecordModel = new TestCertificateRecordModel();
            var lstTestCertificateRecord = await _context.TestCertificateRecords.Where(x => x.IsApproved == null || x.IsApproved == 0).ToListAsync();
            return View(lstTestCertificateRecord);
        }
        public async Task<IActionResult> ApproveCertificate(int? id)
        {
            if (id == null || _context.TestCertificateRecords == null)
            {
                return NotFound();
            }
            var Data = new TestCertificateRecordModel();
            var testCertificateRecord = await _context.TestCertificateRecords.FindAsync(id);
            if (testCertificateRecord != null)
            {
                Data.CertificateNo = testCertificateRecord.CertificateNo;
                Data.CustomerName = testCertificateRecord.CustomerName;
                Data.IssueDate = testCertificateRecord.IssueDate;
                Data.Quanity = testCertificateRecord.Quanity;
                Data.InvoiceNo = testCertificateRecord.InvoiceNo;
                Data.TradeDesignation = testCertificateRecord.TradeDesignation;
                Data.Size = testCertificateRecord.Size;
                Data.BatchDate = testCertificateRecord.BatchDate;
                Data.BatchNo = testCertificateRecord.BatchNo;
                Data.ManufecturingDate = testCertificateRecord.ManufecturingDate;
                Data.Specification = testCertificateRecord.Specification;
                Data.WeldingProcess = testCertificateRecord.WeldingProcess;
                Data.ShieldingGas = testCertificateRecord.ShieldingGas;
                Data.PreHeatInerpassTemp = testCertificateRecord.PreHeatInerpassTemp;
                Data.Type = testCertificateRecord.Type;
                Data.Apms = testCertificateRecord.Apms;
                Data.FlowRate = testCertificateRecord.FlowRate;
                Data.CurrentPolarity = testCertificateRecord.CurrentPolarity;
                Data.Volts = testCertificateRecord.Volts;
                Data.TravelSpeed = testCertificateRecord.TravelSpeed;
                Data.BaseMetal = testCertificateRecord.BaseMetal;
                Data.ElementMinC = testCertificateRecord.ElementMinC;
                Data.ElementMinSi = testCertificateRecord.ElementMinSi;
                Data.ElementMinMn = testCertificateRecord.ElementMinMn;
                Data.ElementMinP = testCertificateRecord.ElementMinP;
                Data.ElementMinS = testCertificateRecord.ElementMinS;
                Data.ElementMinNi = testCertificateRecord.ElementMinNi;
                Data.ElementMinCr = testCertificateRecord.ElementMinCr;
                Data.ElementMinMo = testCertificateRecord.ElementMinMo;
                Data.ElementMinCu = testCertificateRecord.ElementMinCu;
                Data.ElementMaxC = testCertificateRecord.ElementMaxC;
                Data.ElementMaxSi = testCertificateRecord.ElementMaxSi;
                Data.ElementMaxMn = testCertificateRecord.ElementMaxMn;
                Data.ElementMaxP = testCertificateRecord.ElementMaxP;
                Data.ElementMaxS = testCertificateRecord.ElementMaxS;
                Data.ElementMaxNi = testCertificateRecord.ElementMaxNi;
                Data.ElementMaxCr = testCertificateRecord.ElementMaxCr;
                Data.ElementMaxMo = testCertificateRecord.ElementMaxMo;
                Data.ElementMaxCu = testCertificateRecord.ElementMaxCu;
                //Data.ElementResultC = testCertificateRecord.ElementResultC;
                //Data.ElementResultSi = testCertificateRecord.ElementResultSi;
                //Data.ElementResultMn = testCertificateRecord.ElementResultMn;
                //Data.ElementResultP = testCertificateRecord.ElementResultP;
                //Data.ElementResultS = testCertificateRecord.ElementResultS;
                //Data.ElementResultNi = testCertificateRecord.ElementResultNi;
                //Data.ElementResultCr = testCertificateRecord.ElementResultCr;
                //Data.ElementResultMo = testCertificateRecord.ElementResultMo;
                //Data.ElementResultCu = testCertificateRecord.ElementResultCu;
                Data.TestMinUts = testCertificateRecord.TestMinUts;
                Data.TestMinYs = testCertificateRecord.TestMinYs;
                Data.TestMinElongation = testCertificateRecord.TestMinElongation;
                Data.TestMaxUts = testCertificateRecord.TestMaxUts;
                Data.TestMaxYs = testCertificateRecord.TestMaxYs;
                Data.TestMaxElongation = testCertificateRecord.TestMaxElongation;
                //Data.TestResultUts = testCertificateRecord.TestResultUts;
                //Data.TestResultYs = testCertificateRecord.TestResultYs;
                //Data.TestResultElongation = testCertificateRecord.TestResultElongation;
                Data.TestTemp = testCertificateRecord.TestTemp;
                Data.TestImpectValue = testCertificateRecord.TestImpectValue;
                Data.TestCondition = testCertificateRecord.TestCondition;
                Data.SizeStandardValue = testCertificateRecord.SizeStandardValue;
                Data.SizeActualValue = testCertificateRecord.SizeActualValue;
                Data.CoatingStandardValue = testCertificateRecord.CoatingStandardValue;
                Data.CoatingActualValue = testCertificateRecord.CoatingActualValue;
                Data.UtswireStandardValue = testCertificateRecord.UtswireStandardValue;
                Data.UtswireActualValue = testCertificateRecord.UtswireActualValue;
                Data.CastDiaStandardValue = testCertificateRecord.CastDiaStandardValue;
                Data.CastDiaActualValue = testCertificateRecord.CastDiaActualValue;
                Data.HelixStandardValue = testCertificateRecord.HelixStandardValue;
                Data.HelixActualValue = testCertificateRecord.HelixActualValue;
                Data.OtherTestRadioSpecs = testCertificateRecord.OtherTestRadioSpecs;
                Data.OtherTestFaceBendSpecs = testCertificateRecord.OtherTestFaceBendSpecs;
                Data.OtherTestFilledSpecs = testCertificateRecord.OtherTestFilledSpecs;
                //Data.OtherTestResultRadioSpecs = testCertificateRecord.OtherTestResultRadioSpecs;
                //Data.OtherTestResultFaceBendSpecs = testCertificateRecord.OtherTestResultFaceBendSpecs;
                //Data.OtherTestResultFilledSpecs = testCertificateRecord.OtherTestResultFilledSpecs;
                Data.Remarks = testCertificateRecord.Remarks;
                Data.CertificateType = "System";
                Data.CreatedDate = testCertificateRecord.CreatedDate;
                Data.CreatedBy = testCertificateRecord.CreatedBy;
                Data.ModifiedDate = testCertificateRecord.ModifiedDate;
                Data.ModifiedBy = testCertificateRecord.ModifiedBy;
            }
            if (Data == null)
            {
                return NotFound();
            }
            return View(Data);
        }

        [HttpPost]
        public JsonResult SaveCertificateResultData(string BatchNo, string Size, string CertificateNo, 
            decimal ElementResultC, decimal ElementResultSi, decimal ElementResultMn, decimal ElementResultP, 
            decimal ElementResultS,decimal ElementResultNi,decimal ElementResultCr,decimal ElementResultMo,
            decimal ElementResultCu,decimal TestResultUts,decimal TestResultYs,decimal TestResultElongation,
            string TestResultTemp, string TestResultImpectValue, string TestResultCondition,
            string OtherTestResultRadioSpecs,string OtherTestResultFaceBendSpecs,string OtherTestResultFilledSpecs
            )
        {
            
            TestCertificateResultRecord testCertificateResultRecord  = new TestCertificateResultRecord()
            {
                 
                BatchNo = BatchNo,
                Size = Size,
                CertificateNo = CertificateNo,
                ElementResultC = ElementResultC,
                ElementResultSi = ElementResultSi,
                ElementResultMn = ElementResultMn,
                ElementResultP = ElementResultP,
                ElementResultS = ElementResultS,
                ElementResultNi = ElementResultNi,
                ElementResultCr = ElementResultCr,
                ElementResultMo = ElementResultMo,
                ElementResultCu = ElementResultCu,
                TestResultUts = TestResultUts,
                TestResultYs = TestResultYs,
                TestResultElongation = TestResultElongation,
                TestTemp = TestResultTemp,
                TestImpectValue = TestResultImpectValue,
                TestCondition = TestResultCondition,
                OtherTestResultRadioSpecs = OtherTestResultRadioSpecs,
                OtherTestResultFaceBendSpecs = OtherTestResultFaceBendSpecs,
                OtherTestResultFilledSpecs = OtherTestResultFilledSpecs,
                CreatedBy = HttpContext.Session.GetString("lid"),
                CreatedDate = DateTime.Now,

            };
            _context.TestCertificateResultRecords.Add(testCertificateResultRecord);
            _context.SaveChanges();
            return Json(CertificateNo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveCertificate(int id, TestCertificateRecordModel testCertificateRecord1)
        {
           
            var Data = await _context.TestCertificateRecords.FindAsync(id);
            if (Data != null)
            {
                Data.IsApproved = 1;
               
                Data.ModifiedDate = DateTime.Now;
                Data.ModifiedBy = HttpContext.Session.GetString("lid");

                _context.Update(Data);
                await _context.SaveChangesAsync();
            }
            if (Data == null)
            {
                return NotFound();
            }
            return RedirectToAction("UnApprovedCertificateList");
        }


        // GET: TestCertificateRecordController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestCertificateRecordController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private bool TestCertificateRecordExists(int id)
        {
            return (_context.TestCertificateRecords?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        //=====================
        public JsonResult GetTradeDesignationDataMaster( string  TradeDesignation)
        {
            var data = _context.TradeDesignationMasters.Where(x => x.TradeDesignation == TradeDesignation).ToList();

            return Json(data);
        }

        public JsonResult GetSizeDataMaster(string Size)
        {
            var data = _context.SizeMasters.Where(x => x.Size == Size).ToList();

            return Json(data);
        }

        public JsonResult GetBatchMasterResult(string BatchNo)
        {
                var data = _context.BatchMasters.Where(x => x.BatchNo == BatchNo).ToList();

            return Json(data);
        }

    }
}
