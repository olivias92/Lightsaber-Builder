import * as THREE from '/js/three.module.min.js';
/*import { STLLoader } from "/three/examples/jsm/loaders/STLLoader.js";*/
import { STLLoader } from "/js/STLLoader.js";

console.log( "stlLoad.js is running!");
document.addEventListener("DOMContentLoaded", function () {
    console.log(" Three.js script is executing...");

    try {
        console.log(" THREE.js version:", THREE.REVISION);
    } catch (error) {
        console.error(" Error: THREE.js is not loaded!");
    }
});


console.log("Three.js STL Viewer initialized!");

const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
const renderer = new THREE.WebGLRenderer();
renderer.setSize(window.innerWidth, window.innerHeight);

document, addEventListener("DOMContentLoaded", function () {
    const container = document.getElementById("threejs-container").appendChild(renderer.domElement);
    if (!container) {
        console.error("Error");
        return;
    }
    console.log("Success");
});
/*const container = document.getElementById("threejs-container").appendChild(renderer.domElement);*/

const loader = new STLLoader();
loader.load("/ModelsLS/Elemental Nature/EN_Emitter_1.stl", function (geometry) {
    const material = new THREE.MeshStandardMaterial({ color: 0x00ff00 });
    const mesh = new THREE.Mesh(geometry, material);
    scene.add(mesh);
});

// Render loop
camera.position.z = 5;
function animate() {
    requestAnimationFrame(animate);
    renderer.render(scene, camera);
}
animate();