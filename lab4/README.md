Lab 4

Video:  
https://drive.google.com/file/d/16q-gHV55yYRGWPdb8ebGtwht5EgVlpuQ/view?usp=sharing  

Questions:  

A. x = u * (xsize - 1) (in this case 8 is the max, -1 to account for 'off by one');  
e.g. 1 on the uv coordinate corresponds to 7 on the texture map.  

B. y = u * (ysize - 1) (in this case it is also 7).  

C. uv = (.375, .025);  
x = .375 * (8 - 1) = 2.625 -> corresponds to cell 2, x = 2.  
y = .25 * (8 - 1) =  1.75  -> correspongs to cell 1, y = 1.  
Our x,y coords are (2, 1), which is the color blue.

Cube descriptions:  

Middle Cube: Done through lab tutorial utilizing both a texture and normal map.  
Left Cube: Done through lab tutorial only using a texture.  
Top Cube: Similar to middle cube, however different texture and normal map used.  
Right Cube: Done through lab tutorial using a texture, and shaders provided by the tutorial.  
Bottom Cube: Similar to right cube in that it has a unique texture, and uses a fragment shader I built.  
Disclaimer for bottom cube:  
I do not believe I tiled the cube the intended way. The code I wrote is a hard coded solution and is not modular  
to tiling it to other nxn basis. To do so would involve changing raw numbers, and adding additional if statements.  
I am unsure of the proper way to do this, but here is the code used in the shader:  
uniform sampler2D texture1;  
varying vec2 vUv;  
void main() { //hard coded solution  
	vec2 spare = vUv * 2.0;  //map the cube such that coordinates fetch values 2x their original (2x for 2x2)  
	if (vUv.x > 0.5) spare.x -= 1.0;  //since this will cause some values to try and fetch values  
	if (vUv.y > 0.5) spare.y -= 1.0;  //outside of unit texture square, adjust for the error  
	gl_FragColor = texture2D(texture1, spare);  
}
