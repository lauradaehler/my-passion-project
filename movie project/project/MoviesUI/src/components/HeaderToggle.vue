<template>
    <header>
        <toggle-theme :mode="mode" @toggle="$emit('toggle')"></toggle-theme>

    </header>
</template>

<script>
import ToggleTheme from './ToggleTheme.vue';

export default {
    props: ["mode"],
    components: {
        ToggleTheme
    }
}
</script>

<style>

.pink {
    background-color: rgb(255, 188, 220);
    color: rgb(255, 27, 133);
}


</style>