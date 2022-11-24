delete from Department where true;
insert into Department (Name, Description) VALUES ("Guitars", "Acoustic and electric guitars, banjos, and others");
insert into Department (Name, Description) VALUES ("Amplifiers", "Guitar and bass amplifiers");
insert into Department (Name, Description) VALUES ("Effect Units", "Guitar and bass effect units");
insert into Department (Name, Description) VALUES ("Bass Guitars", "Acoustic and electric bass guitars");
insert into Department (Name, Description) VALUES ("Drums and Percussion", "Drums, cymbals, hardware and percussion");
insert into Department (Name, Description) VALUES ("Keyboards", "Pianos and keyboards");
insert into Department (Name, Description) VALUES ("Pro Audio", "Interfaces, DJ equipment, mixers, and more");

delete from Category where true;
insert into Category (Name) VALUES ("6-String Electric Guitars");
insert into Category (Name) VALUES ("7-String Electric Guitars");
insert into Category (Name) VALUES ("6-String Acoustic Guitars");
insert into Category (Name) VALUES ("Ukeleles");
insert into Category (Name) VALUES ("4-String Bass Guitars");
insert into Category (Name) VALUES ("5-String Bass Guitars");
insert into Category (Name) VALUES ("Acoustic Bass Guitars");

# Insert Guitars - dept 1
# Use the LesPaul.jpg as an example for insert.
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('JM-34751', 'Fender Jazzmaster', 'Fender Jazzmaster in Daphne Blue.', 2999.99, 2599.99, 'jazzmaster.jpg', 12, 1);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('CB-18375', 'Cordoba Flamenco Guitar', 'Cordoba flamenco guitar with tap plates.', 699.99, 649.99, 'cordoba.jpg', 5, 1);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('EP-PR5E', 'Epiphone PR5-E', 'Easy playing florentine cut acoustic guitar.', 399.99, 379.99, 'epiphone.jpg', 30, 1);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('MO-1937', 'Godin MultiOud', '11-string electric oud instrument', 1659.99, 1600, 'godin.jpg', 12, 1);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('SH-4677', 'Schecter Hellraiser C-7 (Used)', '7-string guitar by Schecter.', 799.99, 399.99, 'schecter.jpg', 1, 1);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('FT-23457', 'Fender Telecaster', 'Fender Tex-Mex Telecaster with custom scratch plate and Gilmour mod.', 599.99, 599.99, 'tele.jpg', 1, 1);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('FS-123857', 'Fender American HSS Stratocaster', 'HSS American Strat, ebony neck, alder body', 1299.99, 1199.99, 'strat.jpg', 10, 1);
    
# Insert Amplifiers - dept 2
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('FB-BB1247', 'Fender Bassbreaker 15', '15-watt combo amp with effects loop', 799, 799, 'bassbreaker.jpg', 5, 2);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('VX-475215', 'Victory VX Kraken', '50-watt dual channel valve amplifier', 1499, 1499, 'vx.jpg', 15, 2);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('EV-347534', 'EVH 5150 III 50W', '50-watt American high gain amplifier, 3 channels', 1499, 1499, 'evh.jpg', 15, 2);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('VX-25745', 'Vox Bass Amp', '10-watt practice amp for bass', 49, 49, 'vox.jpg', 7, 2);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('SU-2357', 'Suhr Reactive IR Load Box', 'Crank your amp without waking the neighbors. Comes with 16 IR presets', 699, 699, 'suhr.jpg', 15, 2);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('FM-1238457', 'Furman Power Conditioner', 'Get clean, reliable power distribution in any environment.', 399, 299, 'furman.jpg', 15, 2);
    
# Insert Effect Units - dept 3
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('MX-CCDEL1', 'MXR Carbon Copy Delay', 'Analog delay pedal with mod function', 149, 149, 'carboncopy.jpg', 2, 3); 
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('MX-P90', 'MXR Phase 90', 'Iconic, single-knob phaser reminiscent of a certain Eddie.', 99, 89, 'phase90.jpg', 19, 3); 
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('BS-BF2', 'Boss BF-2 Flanger (Used)', 'Japanese import of the BF-2 Flanger', 200, 200, 'flanger.jpg', 2, 3); 
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('TC-HOF1', 'TC Electronic Hall of Fame Reverb', 'Highly configurable and popular reverb', 249, 249, 'hof.jpg', 20, 3); 
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('HZ-PRECIS', 'Horizon Devices Precision Overdrive', 'Tone shaping overdrive with variable gate', 249, 249, 'horizon.jpg', 12, 3); 
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('DR-3457', 'Devi Ever Rocket Fuzz (Used)', 'No longer in production, this fuzz provides two circuits to play with.', 299, 299, 'rocket.jpg', 1, 3); 
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('KM-12357', 'Korg Miku', 'A pedal designed to replicate the vocal utterances of Hatsune Miku.', 299, 299, 'miku.jpg', 1, 3); 
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('EH-A5828', 'Electro-Harmonix Ravish Sitar', 'Replicates the sound of a sitar.', 349, 349, 'sitar.jpg', 2, 3); 
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('VK-V4JACK', 'Victory V4 The Jack Preamp', 'Clean and high-gain channels to be used as a preamp before the power stage of any amplifier.', 499, 499, 'jack.jpg', 20, 3); 
    
# Bass guitars (dept 4)
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('RG-23453', 'Rogue 5-string Bass', 'Active pickups, 5 strings', 149, 149, 'rogue.jpg', 5, 4);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('FB-23757', 'Fender Bronco Bass', 'Shorter scale-length bass suitable for beginners and smaller hands.', 189, 169, 'bronco.jpg', 3, 4); 
    
# Drums and percussion (dept 5)
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('AL-EDKDM10', 'Alesis DM-10 Electronic Drum Kit', '6-piece electronic drum kit with mesh heads, 3 cymbals and a hi-hat. Module included.', 999, 899, 'alesis_drums.jpg', 10, 5); 
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('TM-SSCFK', 'TAMA Silverstar Classic 7-piece Drum Set', '7-piece kit in Trans Blue with shells and hardware (cymbals not included)', 2899, 2899, 'drums.jpg', 4, 5); 
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('SB-C14', 'Sabian 14 Inch Crash Cymbal', 'Medium thin crash cymbal', 129, 129, 'crash_mt14.jpg', 20, 5);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('SB-C16', 'Sabian 16 Inch Crash Cymbal', 'Medium thin crash cymbal', 139, 139, 'crash_mt16.jpg', 20, 5);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('SB-C10', 'Sabian 10 Inch Splash Cymbal', 'Bright sounding splash cymbal from Sabian', 99, 99, 'splash.jpg', 20, 5);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('ZH-ZHTCHN', 'Zildjian ZHT China Splash', 'Aggressive and bright souning china splash cymbal', 129, 129, 'zht.jpg', 20, 5);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('MN-BELL1234', 'Meinl Bell Cymbal', 'Loud, brash bell sound from Meinl', 149, 129, 'meinl_bell.jpg', 20, 5);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('MN-HOLYCHINA', 'Meinl Holy China Cymbal', 'China Cymbal with holes for added variable resonance', 289, 289, 'meinl_china.jpg', 20, 5);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('SB-HH1235', 'Sabian 14 Inch Hi Hat Set', 'Medium-thin bright hi hats. Top and bottom included.', 169, 169, 'hihat.jpg', 20, 5);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('SB-20RD', 'Sabian 20 Inch Ride Cymbal', 'Standard bell ride cymbal, 20 inch diameter.', 219, 199, 'ride.jpg', 20, 5);

# Keyboards/pianos (dept 6)
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('AK-23457', 'AKAI Mini Pro MIDI Controller', '39 keys, 8 drum pads, automatable faders', 149.99, 149.99, 'akai.jpg', 20, 6);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('MA-3457', 'M-Audio Oxygen 49 MIDI Controller', '49 keys, multiple faders, works with any DAW', 169.99, 169.99, 'oxygen.jpg', 10, 6);
    
# Pro audio (dept 7)
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('FR-4357', 'Focusrite 18i20 Audio Interface', '18 inputs and 20 outputs. Suitable for recording small drum setups.', 499.99, 499.99, 'focusrite.jpg', 20, 7);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('AL-1M34', 'Alesis Stereo Mixer', 'Small format dual channel mixer. Microphone and instrument inputs. USB capable.', 99.99, 89.99, 'alesis_mixer.jpg', 20, 7);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('IK_ADSFN', 'IK Multimedia Studio Monitors', 'Pair of studio monitors that can learn from the environment around you for the optimum monitoring experience.', 799.99, 799.99, 'ik.jpg', 6, 7);
insert into Item (SKU, Name, Description, MSRP, Price, PhotoURI, InventoryCount, DepartmentID)
	VALUES ('RD-267A35', 'Radial Studio Reamper', 'Send your recorded DI signal through your rig to get fresh new tones.', 249.99, 249.99, 'reamp.jpg', 20, 7);

delete from SalesEngineer where true;
insert into SalesEngineer (FirstName, LastName, Email, Phone, SpecialtyDepartmentID, PhotoURI)
	VALUES('Dan', 'Waters', 'danwaters@my.unt.edu', '469-993-3300', 1, 'dan_hs.jpg');