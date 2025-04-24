using COMP003._5._8Assignment.Models;
using COMP003._5._8Assignment.Data;
using Microsoft.AspNetCore.Mvc;

namespace COMP003._5._8Assignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : Controller 
    {
        [HttpGet]
        public ActionResult<List<Assignment>> GetAssignment()
        {
            return Ok(AssignmentStore.Assignments);
        }
        [HttpGet("{id}")]
        public ActionResult<Assignment> GetAssignment(int id)
        {
            var assignment = AssignmentStore.Assignments.FirstOrDefault(a => a.Id == id);
           
            if (assignment is null)
                return NotFound();

            return Ok(assignment);
        }
        [HttpPost]
        public ActionResult<Assignment> CreateAssignment(Assignment assignment)
        {
            assignment.Id = AssignmentStore.Assignments.Max(a => a.Id) + 1;
            AssignmentStore.Assignments.Add(assignment);
            return CreatedAtAction(nameof(GetAssignment), new { id = assignment.Id }, assignment);
        
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAssignment(int id, Assignment updatedAssignment)
        {
            var existingAssignment = AssignmentStore.Assignments.FirstOrDefault(a => a.Id == id);
            if (existingAssignment is null)
                return NotFound();

            existingAssignment.Name = updatedAssignment.Name;
            existingAssignment.Subject = updatedAssignment.Subject;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            var Assignment = AssignmentStore.Assignments.FirstOrDefault(a => a.Id == id);
            if (Assignment is null)
                return NotFound();

            AssignmentStore.Assignments.Remove(Assignment);
            return NoContent();
        }
        [HttpGet("filter")]
        public ActionResult<List<Assignment>> FilterAssignment(string Subject)
        {
            var filteredAssignments = AssignmentStore.Assignments
                .Where(a => a.Subject == Subject)
                .OrderBy(a => a.Name)
                .ToList();

            return Ok(filteredAssignments);
        
        }
        [HttpGet("names")]
        public ActionResult<List<string>> GetAssignmentNames()
        {
            var assignmentNames = AssignmentStore.Assignments
                .OrderBy(a => a.Name)
                .Select(a => a.Name)
                .ToList();
            return Ok(assignmentNames);
        }
   }
}
