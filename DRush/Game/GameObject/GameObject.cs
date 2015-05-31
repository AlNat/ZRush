﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DRush
{
    public class GameObject // Класс для обозначения некого примитива (в 20 кб, ага :) ) - от него "происходят" все остальные объекты
    {

        // Переменные описания объекта
        protected Texture2D objectTexture; // Текстура
        protected Rectangle objectCoordinates; // Прямоугольник тестуры - координаты

        protected Vector2 originalDirection; // Старое направление
        protected Vector2 newDirection; // Направление новое для вращения
        protected float angle; // Угол вращения

        protected Rectangle liveCordinates; // Прямоугольник тестуры линии жизни

        protected bool staticSetting; // Статичен ли объект или нет
        protected int live; // Характеристика жизнь
        protected int level; // Уровень
        protected int exp; // Кол-во очков опыта
        protected int points; // Кол-во очков. Для игрока - это его кол-во, для врагов - это заработок игра после убийства
        protected int damage; // Урон

        // Подумать насчет необходимости этого
        protected int hardCooficient; // Коофицент сложности
        protected int moveCooficient = 5; // Коофициент движения - для больших экранов и тд - 
        //TODO - вынести в настройки!

        
        public virtual void Update() // Виртуальный метод
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        { // Функция рисования
            spriteBatch.Draw(objectTexture, objectCoordinates, Color.White);
            DrawHealth(spriteBatch);
        }

        public void DrawHealth(SpriteBatch spriteBatch)
        {

        }

        public bool IsCollapse(GameObject inputGameObject)
        {
            if (inputGameObject.objectCoordinates.Intersects (objectCoordinates)) // Если прямоугольники координат пересеклись 
                return true;
            else
                return false;
        }

        public bool IsAlive ()
        {
            if ( live > 0 ) // Если объект жив
                return true;
            else
                return false;
        }

        public bool IsStatic() // TODO ИНТЕРФЕЙС
        {
            return staticSetting;
        } 

        /*
        public int HowMuchLive() // Вернули кол-во жизни - для HealthBar 
        { // Будем рисовать HealthBar-ы около объетов
            return live;
        }
         */


    }
}
