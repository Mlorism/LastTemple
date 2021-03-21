using LastTemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTemple.Engine
{
	public static class MapManager
	{
		public static List<LocationMark> Locations { get; set; }

		public static List<LocationMark> GetLocations()
		{
			if (Locations == null)
			{
				Locations = new List<LocationMark>();
				LoadLocations();
			}

			return Locations;
		} // GetLocations()

		public static void LoadLocations()
		{
			LocationMark location = new LocationMark { 
			Name = "Świątynia",
			Width = 0.15,
			Height = 0.77,
			Discovered = true,
			Destination = 0
			};

			Locations.Add(location);

			location = new LocationMark
			{
				Name = "Troja",
				Width = 0.22,
				Height = 0.15,
				Discovered = true,
				Destination = 0
			};

			Locations.Add(location);

			location = new LocationMark
			{
				Name = "Teby",
				Width = 0.48,
				Height = 0.83,
				Discovered = true,
				Destination = 0
			};

			Locations.Add(location);

			location = new LocationMark
			{
				Name = "Posterunek",
				Width = 0.63,
				Height = 0.625,
				Discovered = true,
				Destination = 0
			};

			Locations.Add(location);

			location = new LocationMark
			{
				Name = "Bandyci",
				Width = 0.60,
				Height = 0.97,
				Discovered = true,
				Destination = 0
			};

			Locations.Add(location);

			location = new LocationMark
			{
				Name = "Wyrocznia",
				Width = 0.63,
				Height = 0.55,
				Discovered = true,
				Destination = 0
			};

			Locations.Add(location);

			location = new LocationMark
			{
				Name = "Biblioteka",
				Width = 0.42,
				Height = 0.42,
				Discovered = true,
				Destination = 0
			};

			Locations.Add(location);

			location = new LocationMark
			{
				Name = "Krypta",
				Width = 0.85,
				Height = 0.5,
				Discovered = true,
				Destination = 0
			};

			Locations.Add(location);

			location = new LocationMark
			{
				Name = "Katedra",
				Width = 0.85,
				Height = 0.12,
				Discovered = true,
				Destination = 0
			};

			Locations.Add(location);
		} // LoadLocations()
	}
}
