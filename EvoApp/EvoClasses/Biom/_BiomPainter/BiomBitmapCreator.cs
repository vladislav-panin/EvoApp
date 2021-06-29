using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class BiomBitmapCreator
    {
        ResourceManager resourceManager;
        // ***********************************************************************************************************************************

        public Bitmap _Bg_grass              { get; set; } = null;   // фон травы
        public Bitmap _Bg_sea                { get; set; } = null;   // фон моря
        public Bitmap _Bg_lake               { get; set; } = null;   // фон озера
        public Bitmap _Bg_disert             { get; set; } = null;   // фон пустыни
        public Bitmap _Bg_mountins           { get; set; } = null;   // фон гор
        public Bitmap _Bg_wood               { get; set; } = null;   // фон леса
        public Bitmap _Bg_woodEdge           { get; set; } = null;   // фон леса, опушка

        public Bitmap _GRASS_bush            { get; set; } = null;   // куст травы
        	
		public Bitmap ANIMAL_herb_beaver_1   { get; set; } = null;   // бобр
		public Bitmap ANIMAL_herb_beaver_2   { get; set; } = null;   // бобр
        public Bitmap ANIMAL_herb_deer_1     { get; set; } = null;   // олень
		public Bitmap ANIMAL_herb_deer_2     { get; set; } = null;   // олень
        public Bitmap ANIMAL_herb_goat_1     { get; set; } = null;   // козел
		public Bitmap ANIMAL_herb_goat_2     { get; set; } = null;   // козел
        public Bitmap ANIMAL_herb_rabbit_1   { get; set; } = null;   // кролик
		public Bitmap ANIMAL_herb_rabbit_2   { get; set; } = null;   // кролик
        public Bitmap ANIMAL_herb_sheep_1    { get; set; } = null;   // овца
		public Bitmap ANIMAL_herb_sheep_2    { get; set; } = null;   // овца
        public Bitmap ANIMAL_herb_squirrel_1 { get; set; } = null;   // белка
		public Bitmap ANIMAL_herb_squirrel_2 { get; set; } = null;   // белка

        public Bitmap ANIMAL_omni_badger_1   { get; set; } = null;   // барсук
		public Bitmap ANIMAL_omni_badger_2   { get; set; } = null;   // барсук
        public Bitmap ANIMAL_omni_bear_1     { get; set; } = null;   // медведь
		public Bitmap ANIMAL_omni_bear_2     { get; set; } = null;   // медведь
        public Bitmap ANIMAL_omni_boar_1     { get; set; } = null;   // кабан, боров
		public Bitmap ANIMAL_omni_boar_2     { get; set; } = null;   // кабан, боров
        public Bitmap ANIMAL_omni_hedgehog_1 { get; set; } = null;   // ежик
		public Bitmap ANIMAL_omni_hedgehog_2 { get; set; } = null;   // ежик

        public Bitmap ANIMAL_raptor_fox_1    { get; set; } = null;   // лиса
		public Bitmap ANIMAL_raptor_fox_2    { get; set; } = null;   // лиса
        public Bitmap ANIMAL_raptor_lynx_1   { get; set; } = null;   // рысь
		public Bitmap ANIMAL_raptor_lynx_2   { get; set; } = null;   // рысь
        public Bitmap ANIMAL_raptor_wolf_1   { get; set; } = null;   // волк
		public Bitmap ANIMAL_raptor_wolf_2   { get; set; } = null;   // волк

        public Bitmap URBAN_village_barn     { get; set; } = null;   // амбар
        public Bitmap URBAN_village_house    { get; set; } = null;   // дом
        public Bitmap URBAN_village          { get; set; } = null;   // деревня

        public Bitmap FAST_FOOD_animal       { get; set; } = null;   // копченые животные
        public Bitmap FAST_FOOD_veg          { get; set; } = null;   // сушеные овощи. Или консервированные

        public Bitmap HUMAN_child            { get; set; } = null;   // ребенок        
        public Bitmap HUMAN_man              { get; set; } = null;   // мужчина
        public Bitmap HUMAN_woman            { get; set; } = null;   // женщина

        public Bitmap VEGETABLES_beet        { get; set; } = null;   // свекла
        public Bitmap VEGETABLES_carrot      { get; set; } = null;   // морковка
        public Bitmap VEGETABLES_patato      { get; set; } = null;   // картошка
        public Bitmap VEGETABLES_tomato      { get; set; } = null;   // помидоры

        public Bitmap WOOD_acorn             { get; set; } = null;   // желудь
        public Bitmap WOOD_mushroom          { get; set; } = null;   // гриб
        public Bitmap WOOD_strawberry        { get; set; } = null;   // клубника
        // ***********************************************************************************************************************************

        public BiomBitmapCreator() {

        }

        public void Load ()
        {         
            this.resourceManager = Resources.ResourceManager;
            this.CreateBiomBitmaps();
            this.SetLandscapeBg ();
        }
        // ***********************************************************************************************************************************

        private void CreateBiomBitmaps()
        {
            Bitmap pic;            

            // в этой версии программы размер ячейки 90х90, такой битмап и делаем

            pic = (Bitmap)resourceManager.GetObject("_bgWoodEdge_100x100"      );   _Bg_woodEdge         = new Bitmap(pic, 90, 90);   // фон леса, опушка
            pic = (Bitmap)resourceManager.GetObject("_bgGrass_100x100"         );   _Bg_grass            = new Bitmap(pic, 90, 90);   // фон травы
            pic = (Bitmap)resourceManager.GetObject("_bgSea_100x100"           );   _Bg_sea              = new Bitmap(pic, 90, 90);   // фон моря
            pic = (Bitmap)resourceManager.GetObject("_bgMountins_100x100"      );   _Bg_mountins         = new Bitmap(pic, 90, 90);   // фон гор
            pic = (Bitmap)resourceManager.GetObject("_bgWood_100x100"          );   _Bg_wood             = new Bitmap(pic, 90, 90);   // фон леса, опушка
            pic = (Bitmap)resourceManager.GetObject("_bgDisert_100x100"        );   _Bg_disert           = new Bitmap(pic, 90, 90);   // фон пустыни
            pic = (Bitmap)resourceManager.GetObject("_bgLake_100x100"          );   _Bg_lake             = new Bitmap(pic, 90, 90);   // фон озера

            
			pic = (Bitmap)resourceManager.GetObject("_unit_grass_bush"         );   _GRASS_bush            = new Bitmap(pic, 20, 20);   // куст травы

            pic = (Bitmap)resourceManager.GetObject("_unit_herb_beaver_1"      );   ANIMAL_herb_beaver_1   = new Bitmap(pic, 17, 17);   // бобр_1
			pic = (Bitmap)resourceManager.GetObject("_unit_herb_beaver_2"      );   ANIMAL_herb_beaver_2   = new Bitmap(pic, 17, 17);   // бобр_2
            pic = (Bitmap)resourceManager.GetObject("_unit_herb_deer_1"        );   ANIMAL_herb_deer_1     = new Bitmap(pic, 45, 45);   // олень_1
			pic = (Bitmap)resourceManager.GetObject("_unit_herb_deer_2"        );   ANIMAL_herb_deer_2     = new Bitmap(pic, 45, 45);   // олень_2
            pic = (Bitmap)resourceManager.GetObject("_unit_herb_goat_1"        );   ANIMAL_herb_goat_1     = new Bitmap(pic, 28, 28);   // козел_1
			pic = (Bitmap)resourceManager.GetObject("_unit_herb_goat_2"        );   ANIMAL_herb_goat_2     = new Bitmap(pic, 28, 28);   // козел_2
            pic = (Bitmap)resourceManager.GetObject("_unit_herb_rabbit_1"      );   ANIMAL_herb_rabbit_1   = new Bitmap(pic, 20, 20);   // кролик_1
			pic = (Bitmap)resourceManager.GetObject("_unit_herb_rabbit_2"      );   ANIMAL_herb_rabbit_2   = new Bitmap(pic, 20, 20);   // кролик_2
            pic = (Bitmap)resourceManager.GetObject("_unit_herb_sheep_1"       );   ANIMAL_herb_sheep_1    = new Bitmap(pic, 25, 25);   // овца_1
			pic = (Bitmap)resourceManager.GetObject("_unit_herb_sheep_2"       );   ANIMAL_herb_sheep_2    = new Bitmap(pic, 25, 25);   // овца_2
            pic = (Bitmap)resourceManager.GetObject("_unit_herb_squirrel_1"    );   ANIMAL_herb_squirrel_1 = new Bitmap(pic, 14, 14);   // белка_1
			pic = (Bitmap)resourceManager.GetObject("_unit_herb_squirrel_2"    );   ANIMAL_herb_squirrel_2 = new Bitmap(pic, 14, 14);   // белка_2

            pic = (Bitmap)resourceManager.GetObject("_unit_omni_badger_1"      );   ANIMAL_omni_badger_1   = new Bitmap(pic, 17, 17);   // барсук_1
			pic = (Bitmap)resourceManager.GetObject("_unit_omni_badger_2"      );   ANIMAL_omni_badger_2   = new Bitmap(pic, 17, 17);   // барсук_2
            pic = (Bitmap)resourceManager.GetObject("_unit_omni_bear_1"        );   ANIMAL_omni_bear_1     = new Bitmap(pic, 45, 45);   // медведь_1
			pic = (Bitmap)resourceManager.GetObject("_unit_omni_bear_2"        );   ANIMAL_omni_bear_2     = new Bitmap(pic, 45, 45);   // медведь_2
            pic = (Bitmap)resourceManager.GetObject("_unit_omni_boar_1"        );   ANIMAL_omni_boar_1     = new Bitmap(pic, 32, 32);   // кабан_1
			pic = (Bitmap)resourceManager.GetObject("_unit_omni_boar_2"        );   ANIMAL_omni_boar_2     = new Bitmap(pic, 32, 32);   // кабан_2
            pic = (Bitmap)resourceManager.GetObject("_unit_omni_hedgehog_1"    );   ANIMAL_omni_hedgehog_1 = new Bitmap(pic, 16, 16);   // ежик_1
			pic = (Bitmap)resourceManager.GetObject("_unit_omni_hedgehog_2"    );   ANIMAL_omni_hedgehog_2 = new Bitmap(pic, 16, 16);   // ежик_2

            pic = (Bitmap)resourceManager.GetObject("_unit_raptor_fox_1"       );   ANIMAL_raptor_fox_1    = new Bitmap(pic, 23, 23);   // лиса_1
			pic = (Bitmap)resourceManager.GetObject("_unit_raptor_fox_2"       );   ANIMAL_raptor_fox_2    = new Bitmap(pic, 23, 23);   // лиса_2
            pic = (Bitmap)resourceManager.GetObject("_unit_raptor_lynx_1"      );   ANIMAL_raptor_lynx_1   = new Bitmap(pic, 30, 30);   // рысь_1
			pic = (Bitmap)resourceManager.GetObject("_unit_raptor_lynx_2"      );   ANIMAL_raptor_lynx_2   = new Bitmap(pic, 30, 30);   // рысь_2
            pic = (Bitmap)resourceManager.GetObject("_unit_raptor_wolf_1"      );   ANIMAL_raptor_wolf_1   = new Bitmap(pic, 36, 36);   // волк_1
			pic = (Bitmap)resourceManager.GetObject("_unit_raptor_wolf_2"      );   ANIMAL_raptor_wolf_2   = new Bitmap(pic, 36, 36);   // волк_2
																	           
            pic = (Bitmap)resourceManager.GetObject("_unit_vegetables_beet"    );   VEGETABLES_beet      = new Bitmap(pic, 20, 20);   // свекла
            pic = (Bitmap)resourceManager.GetObject("_unit_vegetables_carrot"  );   VEGETABLES_carrot    = new Bitmap(pic, 20, 20);   // морковка
            pic = (Bitmap)resourceManager.GetObject("_unit_vegetables_patato"  );   VEGETABLES_patato    = new Bitmap(pic, 20, 20);   // картошка
            pic = (Bitmap)resourceManager.GetObject("_unit_vegetables_tomato"  );   VEGETABLES_tomato    = new Bitmap(pic, 20, 20);   // помидоры

            pic = (Bitmap)resourceManager.GetObject("_unit_wood_acorn"         );   WOOD_acorn           = new Bitmap(pic, 20, 20);   // желудь
            pic = (Bitmap)resourceManager.GetObject("_unit_wood_mushroom"      );   WOOD_mushroom        = new Bitmap(pic, 20, 20);   // гриб
            pic = (Bitmap)resourceManager.GetObject("_unit_wood_strawberry"    );   WOOD_strawberry      = new Bitmap(pic, 20, 20);   // клубника

            pic = (Bitmap)resourceManager.GetObject("_unit_human_barn"         );   URBAN_village_barn = new Bitmap(pic, 20, 20);     // амбар
            pic = (Bitmap)resourceManager.GetObject("_unit_human_house"        );   URBAN_village_house = new Bitmap(pic, 20, 20);    // дом
            pic = (Bitmap)resourceManager.GetObject("_unit_human_village"      );   URBAN_village = new Bitmap(pic, 20, 20);  // деревня

            pic = (Bitmap)resourceManager.GetObject("_unit_fastFOOD_animal"    );   FAST_FOOD_animal = new Bitmap(pic, 20, 20);   // дом
            pic = (Bitmap)resourceManager.GetObject("_unit_fastFOOD_veg"       );   FAST_FOOD_veg    = new Bitmap(pic, 20, 20);   // дом

            pic = (Bitmap)resourceManager.GetObject("_unit_human_child"        );   HUMAN_child = new Bitmap(pic, 20, 20);   // ребенок
            pic = (Bitmap)resourceManager.GetObject("_unit_human_man"          );   HUMAN_man   = new Bitmap(pic, 20, 20);   // мужчина
            pic = (Bitmap)resourceManager.GetObject("_unit_human_woman"        );   HUMAN_woman = new Bitmap(pic, 20, 20);   // женщина
    }
        // ***********************************************************************************************************************************

        private void SetLandscapeBg()
        {
            Lands.Desert.   setBackground(_Bg_disert);
            Lands.Sea.      setBackground (_Bg_sea);
            Lands.Mountains.setBackground(_Bg_mountins);
            Lands.Lake.     setBackground(_Bg_lake);
            Lands.Grass.    setBackground(_Bg_grass);
            Lands.WoodEdge. setBackground(_Bg_woodEdge);
            Lands.Wood.     setBackground(_Bg_wood);
        }
        // ***********************************************************************************************************************************
    }
}
