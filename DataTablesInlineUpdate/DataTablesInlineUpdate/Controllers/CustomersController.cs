using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DataTablesInlineUpdate.Models;
using System.Threading.Tasks;
using DataTablesInlineUpdate.ViewModels;

namespace DataTablesInlineUpdate.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.BillingAddress).Include(c => c.ShippingAddress);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.BillingAddressId = new SelectList(db.BillingAddress, "BillingAddressId", "Name");
            ViewBag.ShippingAddressId = new SelectList(db.ShippingAddress, "ShippingAddressId", "Name");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task Create(BillingAddress billing, ShippingAddress shipping, Customer customer, UnitOfWork repo)

        public async Task<ActionResult> Create(CustomerViewModel customModel, UnitOfWork repo)
        {
            if (ModelState.IsValid)
            {
                await repo.AddCustomer(db, customModel);
                return View(new CustomerViewModel());
            }

            ViewBag.BillingAddressId = new SelectList(db.BillingAddress, "BillingAddressId", "Name", customModel.Customer.BillingAddressId);
            ViewBag.ShippingAddressId = new SelectList(db.ShippingAddress, "ShippingAddressId", "Name", customModel.Customer.ShippingAddressId);
            return View(customModel);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillingAddressId = new SelectList(db.BillingAddress, "BillingAddressId", "Name", customer.BillingAddressId);
            ViewBag.ShippingAddressId = new SelectList(db.ShippingAddress, "ShippingAddressId", "Name", customer.ShippingAddressId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerNumber,ShippingAddressId,BillingAddressId,CustomerName,OrganisationNumber,CountryCode,ContactName,MailAddress,PhoneNumber,MobileNumber,AccountId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BillingAddressId = new SelectList(db.BillingAddress, "BillingAddressId", "Name", customer.BillingAddressId);
            ViewBag.ShippingAddressId = new SelectList(db.ShippingAddress, "ShippingAddressId", "Name", customer.ShippingAddressId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
