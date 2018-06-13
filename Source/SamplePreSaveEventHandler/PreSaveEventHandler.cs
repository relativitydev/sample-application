using System;
using System.Runtime.InteropServices;
using kCura.EventHandler;
using kCura.EventHandler.CustomAttributes;
using kCura.Relativity.Client;
using Relativity.API;
using Relativity.Services.Objects;

namespace SamplePreSaveEventHandler
{
	[kCura.EventHandler.CustomAttributes.Description("SamplePreSaveEventHandler")]
	[System.Runtime.InteropServices.Guid("89207066-FD30-4BF4-816A-01A006806071")]
	public class PreSaveEventHandler : kCura.EventHandler.PreSaveEventHandler
	{
		public override Response Execute()
		{
			//Construct a response object with default values.
			kCura.EventHandler.Response retVal = new kCura.EventHandler.Response();
			retVal.Success = true;
			retVal.Message = string.Empty;
			try
			{
				retVal.Success = false;
				string userName = this.Helper.GetAuthenticationManager().UserInfo.FullName;
				retVal.Message = String.Format("Hello {0}! You cannot create an object of this type, but that is expected. This is to prove event handler worked.", userName);

				IAPILog logger = Helper.GetLoggerFactory().GetLogger();
				logger.LogVerbose("Log information throughout execution.");
			}
			catch (Exception ex)
			{
				//Change the response Success property to false to let the user know an error occurred
				retVal.Success = false;
				retVal.Message = ex.ToString();
			}

			return retVal;
		}

		/// <summary>
		///     The RequiredFields property tells Relativity that your event handler needs to have access to specific fields that
		///     you return in this collection property
		///     regardless if they are on the current layout or not. These fields will be returned in the ActiveArtifact.Fields
		///     collection just like other fields that are on
		///     the current layout when the event handler is executed.
		/// </summary>
		public override FieldCollection RequiredFields
		{
			get
			{
				kCura.EventHandler.FieldCollection retVal = new kCura.EventHandler.FieldCollection();
				return retVal;
			}
		}
	}
}
