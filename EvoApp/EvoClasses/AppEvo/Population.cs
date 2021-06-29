using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class Population
    {
		public static AppInitInfo appInfo = new AppInitInfo();

		public BiomBitmapCreator BMPs { get; set; } = new BiomBitmapCreator();

		public UnitContainer _herbivores;
		public UnitContainer _omnis;
		public UnitContainer _raptors;
		public UnitContainer _vegetables;

		public UnitContainer _humans;

		public UnitContainer _house;
		public UnitContainer _villadge;

		public UnitContainer _barn;
		public UnitContainer _fastFood;

		public static int startCount_of_biom_Herbivore  = 500;
		public static int startCount_of_biom_Omni       = 500;
		public static int startCount_of_biom_Raptor     = 500;
		public static int startCount_of_biom_Vegetables = 500;

		public static int startCount_of_biom_Human      = 500;

		public static int startCount_of_biom_House      = 0;
		public static int startCount_of_biom_Villadge   = 0;

		public static int startCount_of_biom_Barn       = 0;
		public static int startCount_of_biom_FastFood   = 0;		
		// ***********************************************************************************************************************************

		public Population() {

			_herbivores = new  UnitContainer (startCount_of_biom_Herbivore );
			_omnis      = new  UnitContainer (startCount_of_biom_Omni      );
			_raptors    = new  UnitContainer (startCount_of_biom_Raptor    );
			_vegetables = new  UnitContainer (startCount_of_biom_Vegetables);

			_humans = new UnitContainer(startCount_of_biom_Human);

			_house   = new UnitContainer (startCount_of_biom_House);
			_villadge = new UnitContainer(startCount_of_biom_Villadge);

			_barn     = new UnitContainer(startCount_of_biom_Barn);
			_fastFood = new UnitContainer (startCount_of_biom_FastFood);			
		}
		// ***********************************************************************************************************************************

		public static GeoEx geo() {
            return Program.app.getDesk().geoEx;
        }

        public static List<List<DeskCell>> Cells() {
            return Program.app.getDesk().cellTable;
        }
        
        public void Generate()
        {
			BMPs.Load();

			SpawnPopulation();
			//InitialPlacePopulation();
        }
        // ***********************************************************************************************************************************

        public void SpawnPopulation()
        {
            for (int idxRow = 0; idxRow < geo().rowCount; idxRow++) {
                for (int idxColumn = 0; idxColumn < geo().colCount; idxColumn++) {

					//CreateAndInitUnit (idxRow, idxColumn);
                    //if (biomByID.Count >= entityMaxCount)
                        return;
                }
            }
        }
		// ***********************************************************************************************************************************

		// idxRow, idxColumn - индексы стороки и колонки ячейки, куда нужно поместить новорожденного обитателя Desk
		// Возвращает юнита - новорожденного обитателя указанного типа
		public UnitBase CreateAndInitUnit (int idxRow, int idxColumn, EUnitType type)
        {
			UnitBase entity = null;/* createUnit(type);
			DeskCell cell = Cells()[idxRow][idxColumn];

			cell. BiomAdd (entity);

			SetUnitOnCell();*/

			return entity;
        }
		// ***********************************************************************************************************************************

		protected void SetUnitOnCell()
		{ 
		}

		// ***********************************************************************************************************************************
		protected UnitBase createUnit(EUnitType type, EUnitSex sex)
		{
			UnitBase unit = null;
			switch (type)
			{
				case EUnitType.EHerbivoreDeer:
					unit = new HerbivoreDeer(_herbivores.idGen.getID(), sex);
					_herbivores.unitByID.Add(unit.ID, unit);
					appInfo.countBiomHerbivoreDeer++;
					break;

				case EUnitType.EHerbivoreRabbit:
					unit = new HerbivoreRabbit(_herbivores.idGen.getID(), sex);
					_herbivores.unitByID.Add(unit.ID, unit);
					appInfo.countBiomHerbivoreRabbit++;
					break;

				case EUnitType.EHerbivoreSquirrel:
					unit = new HerbivoreSquirrel(_herbivores.idGen.getID(), sex);
					_herbivores.unitByID.Add(unit.ID, unit);
					appInfo.countBiomHerbivoreSquirrel++;
					break;

				case EUnitType.EOmniBadger:
					unit = new OmniBadger(_omnis.idGen.getID(), sex);
					_omnis.unitByID.Add(unit.ID, unit);
					appInfo.countBiomOmniBadger++;
					break;

				case EUnitType.EOmniBear:
					unit = new OmniBear(_omnis.idGen.getID(), sex);
					_omnis.unitByID.Add(unit.ID, unit);
					appInfo.countBiomOmniBear++;
					break;

				case EUnitType.EOmniBoar:
					unit = new OmniBoar(_omnis.idGen.getID(), sex);
					_omnis.unitByID.Add(unit.ID, unit);
					appInfo.countBiomOmniBoar++;
					break;

				case EUnitType.ERaptorFox:
					unit = new RaptorFox(_raptors.idGen.getID(), sex);
					_raptors.unitByID.Add(unit.ID, unit);
					appInfo.countBiomRaptorFox++;
					break;

				case EUnitType.ERaptorLynx:
					unit = new RaptorLynx(_raptors.idGen.getID(), sex);
					_raptors.unitByID.Add(unit.ID, unit);
					appInfo.countBiomRaptorLynx++;
					break;

				case EUnitType.ERaptorWolf:
					unit = new RaptorWolf(_raptors.idGen.getID(), sex);
					_raptors.unitByID.Add(unit.ID, unit);
					appInfo.countBiomRaptorWolf++;
					break;

				case EUnitType.EVegetableCarrot:
					unit = new VegetableCarrot(_vegetables.idGen.getID());
					_vegetables.unitByID.Add(unit.ID, unit);
					appInfo.countBiomVegetableCarrot++;
					break;

				case EUnitType.EVegetableMushroom:
					unit = new VegetableMushroom(_vegetables.idGen.getID());
					_vegetables.unitByID.Add(unit.ID, unit);
					appInfo.countBiomVegetableMushroom++;
					break;

				case EUnitType.EVegetablePatato:
					unit = new VegetablePatato(_vegetables.idGen.getID());
					_vegetables.unitByID.Add(unit.ID, unit);
					appInfo.countBiomVegetablePatato++;
					break;

				case EUnitType.EVegetableTomato:
					unit = new VegetableTomato(_vegetables.idGen.getID());
					_vegetables.unitByID.Add(unit.ID, unit);
					appInfo.countBiomVegetableTomato++;
					break;

				case EUnitType.EVegetableStrawberry:
					unit = new VegetableStrawberry(_vegetables.idGen.getID());
					_vegetables.unitByID.Add(unit.ID, unit);
					appInfo.countBiomVegetableStrawberry++;
					break;

				case EUnitType.EHumanChild:
					unit = new Child(_humans.idGen.getID(), sex);
					_humans.unitByID.Add(unit.ID, unit);
					appInfo.countBiomHumanChildren++;
					break;

				case EUnitType.EHumanMen:
					unit = new Man(_humans.idGen.getID());
					_humans.unitByID.Add(unit.ID, unit);
					appInfo.countBiomHumanMan++;
					break;

				case EUnitType.EHumanWoman:
					unit = new Woman(_humans.idGen.getID());
					_humans.unitByID.Add(unit.ID, unit);
					appInfo.countBiomHumanWoman++;
					break;

				case EUnitType.EVillige:
					unit = new Village(_house.idGen.getID());
					_house.unitByID.Add(unit.ID, unit);
					appInfo.countBiomVillige++;
					break;

				case EUnitType.EVilligeHouse:
					unit = new VillageHouse(_house.idGen.getID());
					_house.unitByID.Add(unit.ID, unit);
					appInfo.countBiomVilligeHouse++;
					break;

				case EUnitType.EVilligeBarn:
					unit = new VillageBarn(_house.idGen.getID());
					_house.unitByID.Add(unit.ID, unit);
					appInfo.countBiomVilligeBarn ++;
					break;

				case EUnitType.EFastFoodFromAnimal:
					unit = new FastFoodAnimal(_house.idGen.getID());
					_fastFood.unitByID.Add(unit.ID, unit);
					appInfo.countBiomVilligeBarnAnimal++;
					break;

				case EUnitType.EFastFoodFromVeg:
					unit = new FastFoodVeg(_house.idGen.getID());
					_fastFood.unitByID.Add(unit.ID, unit);
					appInfo.countBiomVilligeBarnVeg++;
					break;					

				default:
					throw new Exception("Затребован неведомый зверь, в методе createEntity(int idxRow, int idxColumn, EUnitType type)");
			}

			return unit;
		}
		// ***********************************************************************************************************************************
		protected void removeUnit(UnitBase unit)
		{
			switch (unit.TYPE)
			{
				case EUnitType.EHerbivoreDeer:
					_herbivores.unitByID.Remove(unit.ID);
					appInfo.countBiomHerbivoreDeer--;
					break;

				case EUnitType.EHerbivoreRabbit:
					_herbivores.unitByID.Remove(unit.ID);
					appInfo.countBiomHerbivoreRabbit--;
					break;

				case EUnitType.EHerbivoreSquirrel:
					_herbivores.unitByID.Remove(unit.ID);
					appInfo.countBiomHerbivoreSquirrel--;
					break;

				case EUnitType.EOmniBadger:
					_omnis.unitByID.Remove(unit.ID);
					appInfo.countBiomOmniBadger--;
					break;

				case EUnitType.EOmniBear:
					_omnis.unitByID.Remove(unit.ID);
					appInfo.countBiomOmniBear--;
					break;

				case EUnitType.EOmniBoar:
					_omnis.unitByID.Remove(unit.ID);
					appInfo.countBiomOmniBoar--;
					break;

				case EUnitType.ERaptorFox:
					_raptors.unitByID.Remove(unit.ID);
					appInfo.countBiomRaptorFox--;
					break;

				case EUnitType.ERaptorLynx:
					_raptors.unitByID.Remove(unit.ID);
					appInfo.countBiomRaptorLynx--;
					break;

				case EUnitType.ERaptorWolf:
					_raptors.unitByID.Remove(unit.ID);
					appInfo.countBiomRaptorWolf--;
					break;

				case EUnitType.EVegetableCarrot:
					_vegetables.unitByID.Remove(unit.ID);
					appInfo.countBiomVegetableCarrot--;
					break;

				case EUnitType.EVegetableMushroom:
					_vegetables.unitByID.Remove(unit.ID);
					appInfo.countBiomVegetableMushroom--;
					break;

				case EUnitType.EVegetablePatato:
					_vegetables.unitByID.Remove(unit.ID);
					appInfo.countBiomVegetablePatato--;
					break;

				case EUnitType.EVegetableTomato:
					_vegetables.unitByID.Remove(unit.ID);
					appInfo.countBiomVegetableTomato--;
					break;

				case EUnitType.EVegetableStrawberry:
					_vegetables.unitByID.Remove(unit.ID);
					appInfo.countBiomVegetableStrawberry--;
					break;

				case EUnitType.EHumanChild:
					_humans.unitByID.Remove(unit.ID);
					appInfo.countBiomHumanChildren--;
					break;

				case EUnitType.EHumanMen:
					_humans.unitByID.Remove(unit.ID);
					appInfo.countBiomHumanMan--;
					break;

				case EUnitType.EHumanWoman:
					_humans.unitByID.Remove(unit.ID);
					appInfo.countBiomHumanWoman--;
					break;

				case EUnitType.EVillige:
					_house.unitByID.Remove(unit.ID);
					appInfo.countBiomVillige--;
					break;

				case EUnitType.EVilligeHouse:
					_house.unitByID.Remove(unit.ID);
					appInfo.countBiomVilligeHouse--;
					break;

				case EUnitType.EVilligeBarn:
					_house.unitByID.Remove(unit.ID);
					appInfo.countBiomVilligeBarn--;
					break;

				case EUnitType.EFastFoodFromAnimal:
					_fastFood.unitByID.Remove(unit.ID);
					appInfo.countBiomVilligeBarnAnimal--;
					break;

				case EUnitType.EFastFoodFromVeg:
					_fastFood.unitByID.Remove(unit.ID);
					appInfo.countBiomVilligeBarnVeg--;
					break;

				default:
					throw new Exception("Не удален неведомый зверь, в методе removeEntity(int idxRow, int idxColumn, EUnitType type)");
			}
		}
		// ***********************************************************************************************************************************
		public Bitmap GetBitmap(EUnitType type, EUnitSex sex)
		{
			switch (type)
			{
				case EUnitType.EHerbivoreDeer:
					return (EUnitSex.EMale == sex) ?  BMPs.ANIMAL_herb_deer_1     : BMPs.ANIMAL_herb_deer_2;

				case EUnitType.EHerbivoreRabbit:
					return (EUnitSex.EMale == sex) ? BMPs.ANIMAL_herb_rabbit_1    : BMPs.ANIMAL_herb_rabbit_2;

				case EUnitType.EHerbivoreSquirrel:
					return (EUnitSex.EMale == sex) ? BMPs.ANIMAL_herb_squirrel_1  : BMPs.ANIMAL_herb_squirrel_2;

				case EUnitType.EOmniBadger:
					return (EUnitSex.EMale == sex) ? BMPs.ANIMAL_omni_badger_1    : BMPs.ANIMAL_omni_badger_2;

				case EUnitType.EOmniBear:
					return (EUnitSex.EMale == sex) ? BMPs.ANIMAL_omni_bear_1      : BMPs.ANIMAL_omni_bear_2;

				case EUnitType.EOmniBoar:
					return (EUnitSex.EMale == sex) ? BMPs.ANIMAL_omni_boar_1      : BMPs.ANIMAL_omni_boar_2;

				case EUnitType.ERaptorFox:
					return (EUnitSex.EMale == sex) ? BMPs.ANIMAL_raptor_fox_1     : BMPs.ANIMAL_raptor_fox_2;

				case EUnitType.ERaptorLynx:
					return (EUnitSex.EMale == sex) ? BMPs.ANIMAL_raptor_lynx_1    : BMPs.ANIMAL_raptor_lynx_2;

				case EUnitType.ERaptorWolf:
					return (EUnitSex.EMale == sex) ? BMPs.ANIMAL_raptor_wolf_1    : BMPs.ANIMAL_raptor_wolf_2;

				case EUnitType.EVegetableCarrot:
					return BMPs.VEGETABLES_carrot;

				case EUnitType.EVegetableMushroom:
					return BMPs.WOOD_mushroom;

				case EUnitType.EVegetablePatato:
					return BMPs.VEGETABLES_patato;

				case EUnitType.EVegetableTomato:
					return BMPs.VEGETABLES_tomato;

				case EUnitType.EVegetableStrawberry:
					return BMPs.WOOD_strawberry;

				case EUnitType.EHumanChild:
					return BMPs.HUMAN_child;

				case EUnitType.EHumanMen:
					return BMPs.HUMAN_man;

				case EUnitType.EHumanWoman:
					return BMPs.HUMAN_woman;

				case EUnitType.EVillige:
					return BMPs.URBAN_village;

				case EUnitType.EVilligeHouse:
					return BMPs.URBAN_village_house;

				case EUnitType.EVilligeBarn:
					return BMPs.URBAN_village_barn;

				case EUnitType.EFastFoodFromAnimal:
					return BMPs.FAST_FOOD_animal;

				case EUnitType.EFastFoodFromVeg:
					return BMPs.FAST_FOOD_veg;

				default:
					throw new Exception("Затребован неведомый зверь, в методе createEntity(int idxRow, int idxColumn, EUnitType type)");
			}
		}
		// ***********************************************************************************************************************************
	}
}
