using System.Collections.Generic;
using PayrollSystem.Models;

namespace PayrollSystem.Data
{
    /// <summary>
    /// Repository responsible for storing and managing PaySlip records in-memory.
    /// Acts as a mock database table for generated salary slips.
    /// Provides functionality to add and retrieve PaySlips.
    /// </summary>
    public class PaySlipRepository
    {
        #region Private Fields

        // Stores all generated payslips in-memory
        private List<PaySlip> _slips = new List<PaySlip>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a newly generated PaySlip into the repository.
        /// </summary>
        /// <param name="slip">PaySlip object to be stored.</param>
        public void Add(PaySlip slip)
        {
            // Persisting PaySlip record in in-memory collection
            _slips.Add(slip);
        }

        /// <summary>
        /// Retrieves all generated PaySlips.
        /// </summary>
        /// <returns>List of PaySlip records.</returns>
        public List<PaySlip> GetAll()
        {
            // Returning all stored payslips
            return _slips;
        }

        #endregion
    }
}
