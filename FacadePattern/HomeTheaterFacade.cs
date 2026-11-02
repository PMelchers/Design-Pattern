﻿namespace FacadePattern
{
    internal class HomeTheaterFacade
    {
        private Amplifier amp;
        private CdPlayer cdPlayer;
        private DvdPlayer dvdPlayer;
        private PopcornPopper popcornPopper;
        private Projector projector;
        private Screen screen;
        private TheaterLights lights;
        private Tuner tuner;

        public HomeTheaterFacade(Amplifier amp, CdPlayer cdPlayer, DvdPlayer dvdPlayer, PopcornPopper popcornPopper, Projector projector, Screen screen, TheaterLights lights, Tuner tuner)
        {
            this.amp = amp;
            this.cdPlayer = cdPlayer;
            this.dvdPlayer = dvdPlayer;
            this.popcornPopper = popcornPopper;
            this.projector = projector;
            this.screen = screen;
            this.lights = lights;
            this.tuner = tuner;
        }

        public void WatchMovie(string movie)
        {
            popcornPopper.On();
            popcornPopper.Pop();

            lights.Dim(10);

            screen.Down();

            projector.On();
            projector.SetInput(dvdPlayer);
            projector.WideScreenMode();

            amp.On();
            amp.SetDvd(dvdPlayer);
            amp.SetSurroundSound();
            amp.SetVolume(5);

            dvdPlayer.On();
            dvdPlayer.Play(movie);
        }

        public void EndMovie()
        {
            popcornPopper.Off();

            lights.On();

            screen.Up();

            projector.Off();

            amp.Off();

            dvdPlayer.Stop();
            dvdPlayer.Eject();
            dvdPlayer.Off();
        }
    }
}
