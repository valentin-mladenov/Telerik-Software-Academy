using System;

namespace CohesionAndCoupling
{
	/// <summary>
	/// Get file name.
	/// </summary>
	public class GetFile
	{
		/// <summary>
		/// Get the extention  of the file.
		/// </summary>
		/// <param name="fileName"Full name of the file</param>
		/// <returns>Extention if there is one.</returns>
		public static string Extension(string fileName)
		{
			int indexOfLastDot = fileName.LastIndexOf(".");
			if (indexOfLastDot == -1)
			{
				return "File has no extention.";
			}

			string extension = fileName.Substring(indexOfLastDot + 1);
			return extension;
		}

		/// <summary>
		/// Get's the name of the file.
		/// </summary>
		/// <param name="fileName">Full name of the file.</param>
		/// <returns>The name of the file without extention.</returns>
		public static string NameWithoutExtension(string fileName)
		{
			int indexOfLastDot = fileName.LastIndexOf(".");
			if (indexOfLastDot == -1)
			{
				return fileName;
			}

			string extension = fileName.Substring(0, indexOfLastDot);
			return extension;
		}
	}
}
