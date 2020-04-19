uniform vec3 colorA;
uniform vec3 colorB;
varying vec3 vUv;

void main() {
  vec3 color = vec3(0.0);
  float foo = abs(sin(vUv.x));
  color = mix(colorA, colorB, foo);
  gl_FragColor = vec4(color, 1.0);
}