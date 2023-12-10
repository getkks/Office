using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
namespace Office.Utilities;
/// <summary>
/// Provides access to imported functions from DLLs.
/// </summary>
public static class DllImports {
	/// <summary>
	/// Creates a new bind context object.
	/// </summary>
	/// <param name="reserved">Reserved parameter.</param>
	/// <param name="bindContext">The created bind context object.</param>
	/// <returns>An integer representing the result of the method call.</returns>
	[DllImport("ole32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern int CreateBindCtx(uint reserved, out IBindCtx bindContext);
	/// <summary>
	/// Retrieves a pointer to the Running Object Table (ROT) that manages the
	/// running objects for the current desktop.
	/// </summary>
	/// <param name="reserved">Reserved parameter.</param>
	/// <param name="prot">A pointer to the retrieved IRunningObjectTable interface pointer.</param>
	[DllImport("ole32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern void GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
}
