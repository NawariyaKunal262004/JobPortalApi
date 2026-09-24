using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]


public class JobsController : ControllerBase
{
    private static List<Job> jobs = new List<Job>
    {
        new Job
        {
            Id = 1,
            Title = "Backend Developer",
            Company = "ABC Tech",
            Location = "Jaipur",
            Salary = 50000
        },
        new Job
        {
            Id = 2,
            Title = ".NET Developer",
            Company = "ABC Tech",
            Location = "Jaipur",
            Salary = 55000
        },
        new Job
        {
            Id = 3,
            Title = "Node.js Developer",
            Company = "XYZ Tech",
            Location = "Jaipur",
            Salary = 45000
        }
    };

    [HttpGet]
    public ActionResult<List<Job>> GetAll() => jobs;

    [HttpGet("{id}")]
    public ActionResult<Job> GetById(int id)
    {
        var job = jobs.FirstOrDefault(j=>j.Id == id);
        return job != null? Ok(job) : NotFound();
    }

    [HttpPost]
    public ActionResult<Job> Create(CreateJobDto dto)
    {
        // 1. Create a new Job
        // 2. Give it an Id
        // 3. Copy values from dto
        // 4. Add it to jobs
        // 5. Return the created job

        var newJob = new Job();
        
         newJob.Id = jobs.Count + 1;
        
        newJob.Title = dto.Title;
        newJob.Company = dto.Company;
        newJob.Location = dto.Location;
        newJob.Salary = dto.Salary;
        
        jobs.Add(newJob);
        
        return CreatedAtAction(nameof(GetById), new { id = newJob.Id} , newJob);
    }

    [HttpPut("{id}")]
    public ActionResult<Job> Update(int id, UpdateJobDto dto)
    {
        // 1. Find existing job
        // 2. If it doesn't exist → NotFound()
        // 3. Update its properties using dto
        // 4. Return updated job

        var job = jobs.FirstOrDefault(j=>j.Id == id);
        if (job == null)
        {
            // return 404
            return NotFound();
        }

        job.Title = dto.Title;
        job.Company = dto.Company;
        job.Location = dto.Location;
        job.Salary = dto.Salary;

        return Ok(job);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // find job
        // if not found
        // remove job
        // return response

        var job = jobs.FirstOrDefault(j=>j.Id == id);

        if (job == null)
        {
            // return 404
            return NotFound();
        }

        jobs.Remove(job);

        return NoContent();
    }
}