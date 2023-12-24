<template>
    <div class="toggle-wrapper">
        <label class="switch">
            <input type="checkbox" v-bind:checked="mode === 'pink' ? 'checked' : false" id="toggleButton" @change="$emit('toggle')">
            <div class="slider round"></div>
        </label>
    </div>
</template>

<script>
export default {
    props: ["mode"]
}
</script>

<style>
.toggle-wrapper {
  display: flex;
  align-items: center;
  position: absolute;
  height: 50px;
  width: 40px;
  padding-bottom: 20px;
}

.switch {
  position: absolute;
  display: inline-block;
  width: 42px;
  height: 20px;
}

.switch input {
    display: none;
}

.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgb(255, 27, 133);
  -webkit-transition: 1s;
  transition: 1s;
  border-radius: 34px;
}

.slider:before {
  position: absolute;
  content: "";
  height: 13px;
  width: 13px;
  left: -0.6rem;
  bottom: 4px;
  background-color: white;
  -webkit-transition: 1s;
  transition: 1s;
  border-radius: 50%;
}

input:checked + .slider {
  background-color: #35495e;
}

input:checked + .slider:before {
  background-color: #19222c;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(36px);
}

.slider:after {
  content: "pink";
  color: white;
  display: block;
  position: absolute;
  transform: translate(-50%, -50%);
  top: 10px;
  left: 3.1em;
  font-size: 9px;
  transition: 1s;
}

input:checked + .slider:after {
  content: "blah";
  left: 1.5em;
  transition: 1s;
}

.p {
    color: #19222c;
}
</style>