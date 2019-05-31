using System;

namespace TeamLibrary.Extensions
{
    /// <summary>
    /// Various language extension methods to extend numeric types
    /// </summary>
    public static class NumericExtensions
    {
        /// <summary>
        /// Calculates a value's percentage of another value.
        /// </summary>
        /// <param name="sender">Value to compare.</param>
        /// <param name="pTotalValue">Total value to compare original to.</param>
        /// <returns>Integer percentage value.</returns>
        public static int PercentageOf(this double sender, double pTotalValue) => Convert.ToInt32(sender * 100 / pTotalValue);
        /// <summary>
        /// Calculates a value's percentage of another value.
        /// </summary>
        /// <param name="sender">Value to compare.</param>
        /// <param name="pTotalValue">Integer percentage value.</param>
        /// <returns>Percent of total</returns>
        public static int PercentageOf(this decimal sender, decimal pTotalValue) => (int)Convert.ToDecimal(sender * 100 / pTotalValue);
        /// <summary>
        /// Calculates a value's percentage of another value.
        /// </summary>
        /// <param name="sender">Value to compare.</param>
        /// <param name="pTotalValue">Total value to compare original to.</param>
        /// <returns>Integer percentage value.</returns>
        public static int PercentageOf(this long sender, long pTotalValue) => Convert.ToInt32(sender * 100 / pTotalValue);
        /// <summary>
        /// Determine if sender is event
        /// </summary>
        /// <param name="sender">Int to work against</param>
        /// <returns>True if even, false if odd</returns>
        public static bool IsEven(this int sender) => sender % 2 == 0;
    }
}
