// Copyright (c) MOSA Project. Licensed under the New BSD License.

using System.Collections.Generic;

namespace Mosa.DeviceSystem
{
	/// <summary>
	/// Disk Controller Manager
	/// </summary>
	public class DiskControllerManager
	{
		/// <summary>
		/// The device manager
		/// </summary>
		protected DeviceManager deviceManager;

		/// <summary>
		/// Initializes a new instance of the <see cref="DiskControllerManager"/> class.
		/// </summary>
		/// <param name="deviceManager">The device manager.</param>
		public DiskControllerManager(DeviceManager deviceManager)
		{
			this.deviceManager = deviceManager;
		}

		/// <summary>
		/// Creates the devices.
		/// </summary>
		/// <param name="diskControllerDevice">The disk controller device.</param>
		/// <returns></returns>
		private void CreateDiskDevices(Device diskControllerDevice)
		{
			var controller = diskControllerDevice.DeviceDriver as IDiskControllerDevice;
			HAL.DebugWriteLine("A");

			for (uint drive = 0; drive < controller.MaximunDriveCount; drive++)
			{
				HAL.DebugWriteLine("B");

				if (controller.Open(drive))
				{
					HAL.DebugWriteLine("C");

					if (controller.GetTotalSectors(drive) == 0)
						continue;

					var configuration = new DiskDeviceConfiguration()
					{
						DriveNbr = drive,
						ReadOnly = false
					};

					deviceManager.Initialize(new DiskDeviceDriver(), diskControllerDevice, configuration, null, null);
				}
			}
		}

		/// <summary>
		/// Creates the disk devices.
		/// </summary>
		public void CreateDiskDevices()
		{
			// FIXME: Do not create disk devices if this method executed more than once

			HAL.DebugWriteLine("A1");

			// Find disk controller devices
			var controllers = deviceManager.GetDevices<IDiskControllerDevice>(DeviceStatus.Online);

			// For each controller
			foreach (var controller in controllers)
			{
				HAL.DebugWriteLine("A2");

				// Create disk devices
				CreateDiskDevices(controller);
			}
		}
	}
}
