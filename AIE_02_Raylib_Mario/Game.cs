using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_02_Raylib_Mario
{
    class Game
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Mario Walkthrough";

        Texture2D marioTexture;
        float marioXPos = 400;
        float marioYPos = 200;
        float marioWidth = 32;
        float marioHeight = 32;
        float moveSpeed = 5;
        float gravity = 8;

        float JumpForce = 35;
        float ResetJumpForce = 20;

        public void LoadGame()
        {
            // TODO: Load game assets here
            marioTexture = Raylib.LoadTexture("./assets/mario_1.png");
        }

        public void Update(float deltaTime)
        {
            // TODO: Update related logic here

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                marioXPos += moveSpeed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                marioXPos -= moveSpeed;
            }

            if (marioXPos > windowWidth)
            {
                marioXPos = 0;
            }
            if (marioXPos < 0 )
            {
                marioXPos = windowWidth;
            }
            //make mario jump
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                marioYPos -= JumpForce;
                JumpForce -= 1;

            }

                //make mario fall
                marioYPos += gravity;

            if ( marioYPos > windowHeight )
            {
                marioYPos = windowHeight;
                JumpForce = ResetJumpForce;
            }
             
                

        }

        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            // TODO: Drawing related logic here

            // draws some text
            Raylib.DrawText("Mario", 10, 10, 32, Color.DARKGRAY);

            // draws a rotating texture in center of screen
            RayLibExt.DrawTexture(marioTexture, marioXPos, marioYPos, marioWidth, marioHeight,
                Color.WHITE, 0, 0.5f, 1.0f);

            Raylib.EndDrawing();
        }
    }
}
