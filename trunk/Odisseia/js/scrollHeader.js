// JScript File


                /******************************************
                * Scrollable content script II- © Dynamic Drive (www.dynamicdrive.com)
                * Visit http://www.dynamicdrive.com/ for full source code
                * This notice must stay intact for use
                ******************************************/

                iens6=document.all||document.getElementById
                ns4=document.layers

                //specify speed of scroll (greater=faster)
                var speed=5

                if (iens6){
                document.write('<div id="container" style="position:relative;width:675px;height:563px;;border:none;overflow:hidden;">')
                document.write('<div id="content" style="position:absolute;width:675px;left:0;top:0">')
                }